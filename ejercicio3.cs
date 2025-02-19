using System;

class CuentaBancaria
{
    private string nombre;
    private string numeroCuenta;
    private double saldo;

    public CuentaBancaria(string nombre, string numeroCuenta, double saldoInicial)
    {
        this.nombre = nombre;
        this.numeroCuenta = numeroCuenta;
        this.saldo = saldoInicial;
    }

    public void RealizarConsignacion(double monto)
    {
        if (monto > 0)
        {
            saldo += monto;
            Console.WriteLine($"Consignación exitosa. Nuevo saldo: {saldo:C}");
        }
        else
            Console.WriteLine("Monto inválido.");
    }

    public void RealizarRetiro(double monto)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: {saldo:C}");
        }
        else
            Console.WriteLine("Monto inválido o saldo insuficiente.");
    }

    public void ConsultarSaldo()
    {
        Console.WriteLine($"Saldo actual de la cuenta {numeroCuenta}: {saldo:C}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el número de cuenta: ");
        string numeroCuenta = Console.ReadLine();
        Console.Write("Ingrese el saldo inicial: ");
        double saldoInicial = double.Parse(Console.ReadLine());

        CuentaBancaria cuenta = new CuentaBancaria(nombre, numeroCuenta, saldoInicial);

        while (true)
        {
            Console.WriteLine("\nMenú: \n1. Consignar\n2. Retirar\n3. Consultar saldo\n4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.Write("Ingrese el monto a consignar: ");
                double monto = double.Parse(Console.ReadLine());
                cuenta.RealizarConsignacion(monto);
            }
            else if (opcion == "2")
            {
                Console.Write("Ingrese el monto a retirar: ");
                double monto = double.Parse(Console.ReadLine());
                cuenta.RealizarRetiro(monto);
            }
            else if (opcion == "3")
                cuenta.ConsultarSaldo();
            else if (opcion == "4")
                break;
            else
                Console.WriteLine("Opción inválida.");
        }
    }
}
