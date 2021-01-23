    public class VolumenPrisma
    {
        public int Apotema, TamLado, NumLados, Altura, Lado;
        public int Perimetro, Area, Volumen;
        public VolumenPrisma()
        {
        }
        public static int cPerimetro (int NumLados, int Lado)
        {
            int P;
            P=(NumLados*Lado);
            return P;    
        }
        public static int cVolumen(int Area, int Altura)
        {
            int V;
            V = Area * Altura;
            return V;
        }
        public static int cArea(int Perimetro, int Apotema)
        {
            int A;
            A = (Perimetro * Apotema)/2;
            return A;
        }
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
            prisma.Perimetro = cPerimetro(prisma.TamLado, prisma.Lado);
            prisma.Area = cArea(prisma.Perimetro, prisma.Apotema);
            prisma.Volumen = cVolumen(prisma.Area, prisma.Altura);
        }
    public static void Imprimir(VolumenPrisma prisma) { 
            Console.WriteLine("Lados= {0} ", prisma.Lado);
            Console.WriteLine("Tam Lado = {0} ", prisma.TamLado);
            Console.WriteLine("Apotema = {0} ", prisma.Apotema);
            Console.WriteLine("Perimetro = {0} ", prisma.Perimetro);
            Console.WriteLine("Area = {0} ", prisma.Area); 
            Console.WriteLine("Volumen = {0} ", prisma.Volumen);
           }
    }
