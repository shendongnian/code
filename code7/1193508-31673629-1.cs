     class Program
    {
        static void Main()
        {
           var ret = new Dictionary<string, int[]>();
            int[] a = { 1, 0, 3, 4, 0 };
            int[] b = { 3, 0, 9, 10, 0 };
            int[] c = { 2, 3, 3, 5, 0 };
            ret.Add("Jack", a);
            ret.Add("Jane", b);
            ret.Add("James", c);
            ret.ForEach(x => Write(x.Value.Count(y => y !=0), x.Key));
            Console.ReadLine();
        }
       
        public static void Write(int count, string key)
        {
            Console.WriteLine("Count of non zeroes in {0} is {1}", key, count);
        }
    }
