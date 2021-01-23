    class Program
    {
        static void Main(string[] args)
        {
            Feld[,] result = new Feld[,] { } ;
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (result[x, y].IsFilled)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.Write(Environment.NewLine);
            }
            Console.Read();
        }
    }
    public class Feld
    {
        public bool IsFilled { get; set; }
        public Feld(bool isFill)
        {
            IsFilled = isFill;
        }
    }
