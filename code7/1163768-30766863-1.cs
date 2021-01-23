    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            list.Sort();
            int Max = list[list.Count - 1];
            Console.WriteLine("{0}", Max);
            Console.ReadLine();
        }
    }
