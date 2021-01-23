     static void Main(string[] args)
        {
            for (int i = 0; i < MethodName().Count; i++ )
            {
                var result = MethodName()[i] as string;
                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
        private static List<string> MethodName()
        {
            var items = new List<string>();
            while (Condition)
            {
                items.Add("SString to return");
            }
            return items;
        }
