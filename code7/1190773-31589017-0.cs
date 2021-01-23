        public static bool StartHi(string str)
        {
            bool firstHi = false;
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("The string is empty!");
                Console.ReadLine();
            }
            var array = str.Split(new string[] {" "}, StringSplitOptions.None);
            if (array[0] == "hi")
            {
                firstHi = true;
                Console.WriteLine("The string starts with \"hi\"");
            }
            else
            {
                firstHi = false;
                Console.WriteLine("The string doesn't start with \"hi\"");
            }
            
            Console.ReadLine();
            return firstHi;
        }
