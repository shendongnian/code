        static void Main(string[] args)
        {
            var dict = new MultiKeyDictionary<string, long, long>();
            dict.Add("abc", 111, 1234);
            dict.Add("def", 222, 7890);
            dict.Add("hij", 333, 9090);
            Console.WriteLine(dict["abc"]); // expect 1234
            Console.WriteLine(dict["def"]); // expect 7890
            Console.WriteLine(dict[333]); // expect 9090
            Console.WriteLine();
            Console.WriteLine("removing def");
            dict.Remove("def");
            Console.WriteLine();
            Console.WriteLine("now we have:");
            foreach (var d in dict.GetKeyValuePairsOfFirstKey())
            {
                Console.WriteLine($"{d.Key} : {d.Value}");
            }
            Console.WriteLine();
            Console.WriteLine("removing 333");
            dict.Remove(333);
            Console.WriteLine();
            Console.WriteLine("now we have:");
            foreach (var d in dict.GetKeyValuePairsOfSecondKey())
            {
                Console.WriteLine($"{d.Key} : {d.Value}");
            }
            Console.ReadLine();
        }
