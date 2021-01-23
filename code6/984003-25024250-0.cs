        static void Main(string[] args)
        {
            Int32 ii = new Int32();
            changeit1(ii);
            Console.WriteLine(ii.ToString());
            changeit2(ii);
            Console.WriteLine(ii.ToString());
            Console.ReadLine();
        }
        static void changeit1(Int32 i) 
        {
            i = 2;
        }
        static void changeit2(ref int i)
        {
            i = 2;
        }
