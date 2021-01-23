    class Program
    {
        static void Main(string[] args)
        {
            VolumenPrisma herramienta = new VolumenPrisma();
            herramienta.Registro();
        }
    }    
    
    namespace Poligono
    {
        public class VolumenPrisma
        {
            private int numLados;
            private int lado;
        
            public double Perimetro
            {               
                get { return numLados * lado; }
            }
                
            public void Registro()
            {
                Console.WriteLine("Indique No. de lados: ");
                numLados = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Indique tamanio de lado: ");
                lado = Int32.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Perimetro = {0} ", Perimetro);
            }
        }
    }
