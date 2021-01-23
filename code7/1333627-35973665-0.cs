    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[10];
            Random r = new Random();
            int i;
            for (i = 0; i < x.Length; i++)
            {
                var next = 0;                
                while (true)
                {
                    next = r.Next(10);
                    if (!Contains(x, next)) break;                    
                }
                x[i] = next;
                Console.WriteLine("x[{0}] = {1}", i, x[i]);
            }
            Console.ReadLine();
        }
        static bool Contains(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value) return true;
            }
            return false;
        }
    }
