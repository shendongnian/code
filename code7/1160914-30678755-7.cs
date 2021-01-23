    namespace Poligono
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i, n;
                VolumenPrisma[] Calculos;
                Console.WriteLine("\n Insert the number of items");
                string entry = Console.ReadLine();
                int.TryParse(entry, out n);
                Calculos = new VolumenPrisma[n]();
                for (i = 0; i < n; i++)
                {
                    Calculos[i] = new VolumenPrisma();    // create a new instance to store the data
                    VolumenPrisma.Registro(Calculos[i]);      //get the parameters for this prisma
                }
                for (i = 0; i < n; i++)
                {
                    VolumenPrisma.Imprimir(Calculos[i]);      //Print results for that prisma
                }
            }
        }
    }
