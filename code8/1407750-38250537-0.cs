    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<string> { "C001", "C010" };
            var firstChar = new List<string>();
            var remainingChars = new List<string>();
            items.ForEach(i =>
            {
                firstChar.Add(i[0].ToString());
                remainingChars.Add(i.Substring(1));
            });
            firstChar.ForEach(f => { Console.Write(f + " "); });
            Console.WriteLine();
            remainingChars.ForEach(r => { Console.Write(r + " "); });
            Console.WriteLine();
            //Prints the following
            //C C
            //001 010
            //Press any key to continue . . .
        }
    }
