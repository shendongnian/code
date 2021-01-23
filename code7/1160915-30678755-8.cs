    public static void Registro(VolumenPrisma prisma)
    {
        Console.WriteLine("Indique No. de lados: ");
        prisma.Lado = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Indique tamanio de apotema: ");
        prisma.Apotema = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Indique tamanio de lado: ");
        prisma.TamLado = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Indique la altura: ");
        prisma.Altura = Int32.Parse(Console.ReadLine());
        Console.WriteLine("----------------------------------------");
        prisma.Perimetro = cPerimetro(TamLado, Lado);
        prisma.Area = cArea(Perimetro, Apotema);
        prisma.Volumen = cVolumen(Area, Altura);
    }
    public static void Imprimir(VolumenPrisma prisma)
    {
        Console.WriteLine("Lados= {0} ", prisma.Lado);
        Console.WriteLine("Tam Lado = {0} ", prisma.TamLado);
        Console.WriteLine("Apotema = {0} ", prisma.Apotema);
        Console.WriteLine("Perimetro = {0} ", prisma.Perimetro);
        Console.WriteLine("Area = {0} ", prisma.Area);
        Console.WriteLine("Volumen = {0} ", prisma.Volumen);
    }
