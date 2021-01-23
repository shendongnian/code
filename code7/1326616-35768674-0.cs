        class Program
    {
        static void Main(string[] args)
        {
            List<int> list1d = new List<int>();
            List<List<int>> list2d = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                list1d = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    list1d.Add(i * j + i);
                }
                list2d.Add(list1d);
            }
            foreach (var result in list2d)
            {
                foreach (var i  in result)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();
        }
    }
