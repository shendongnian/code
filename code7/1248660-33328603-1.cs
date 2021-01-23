        static void Main(string[] args)
        {
            Program a = new Program();
            int[] arr = a.make();
            Console.WriteLine(String.Join(Environment.NewLine, arr));     
            Console.ReadLine();
        }
