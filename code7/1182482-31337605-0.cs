    public static class Helper
    {
        public static List<T> AddElements<T>(this List<T> list, params object[] args)
        {            
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] is T[]) { list.AddRange(args[i] as T[]); continue; }
                list.Add((T)args[i]);
            }
            return list;
        }
    }
    class Class12
    {
        static void Main()
        {
            int n = 4; int n2 = 8;
            int[] ns = { 5, 6, 7 };
            List<int> numbers = new List<int>() { 1, 2, 3 };
            numbers = numbers.AddElements(n, ns, n2);
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + "  "); 
            }
            Console.WriteLine();
        }
    }
