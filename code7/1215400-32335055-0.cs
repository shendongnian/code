        static void Main(string[] args)
        {
            string str = "this  is NOT ok";
            int index = str.IndexOf(' ');
           //check if next character of space is also a space
            if (index >= 0 && str[index + 1] == ' ')
                Console.WriteLine("Not Ok String");
            else
                Console.WriteLine("OK String");
        }
