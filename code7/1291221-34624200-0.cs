        public void numPatternSearch()
        {
            string input3;
            string pattern = @"\b\w+es\b";
            Console.WriteLine("Enter string to search: ");
            input3 = Console.ReadLine();
            string[] substrings = new string[100];
            int count = 1;
            foreach (Match match in Regex.Matches(input3, pattern))
            {
                substrings[count - 1] = string.Format("Number" + count + " = {0}", match);
                Console.WriteLine(substrings[count - 1]);
                count++;
            }
        }
