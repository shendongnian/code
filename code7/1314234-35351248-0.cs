        private static void Main()
        {
            string myString = "Hello world";
            var mySplitedString = myString.ConsistantSplit(' ', 5);
            Console.WriteLine(mySplitedString.Length);
            Console.ReadLine();
        }
        private static string[] ConsistantSplit(this string text, char splitter, int size)
        {
            string[] consistantSplitter = new string[size];
            var splitted = text.Split(splitter);
            if (size < splitted.Length)
                return splitted.Take(size).ToArray();
            splitted.CopyTo(consistantSplitter, 0);
                return consistantSplitter;
        }
