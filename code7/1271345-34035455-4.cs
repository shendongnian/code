    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[] { "a", "b", "c", "d", "e" };
            int[] b = new int[] { 1, 0, 3, 0, 5 };
            for (int i = 0; i < a.Length; i++)
            {
                if (b[i] != 0)
                    Console.WriteLine(a[i] + "=" + b[i]);
            }
            Console.ReadLine();
        }
    }
