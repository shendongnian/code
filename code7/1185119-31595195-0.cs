    public enum NumberVerb
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            ten = 10,
        };
        public static Dictionary<string, NumberVerb> m_Dictionary
        {
            get
            {
                Dictionary<string, NumberVerb> temp = new Dictionary<string, NumberVerb>();
                temp.Add("(one)", NumberVerb.one);
                temp.Add("(two)", NumberVerb.two);
                temp.Add("(three)", NumberVerb.three);
                temp.Add("(four)", NumberVerb.four);
                temp.Add("(five)", NumberVerb.five);
                temp.Add("(six)", NumberVerb.six);
                temp.Add("(seven)", NumberVerb.seven);
                temp.Add("(eight)", NumberVerb.eight);
                temp.Add("(nine)", NumberVerb.nine);
                temp.Add("(ten)", NumberVerb.ten);
                return temp;
            }
        }
        static void Main(string[] args)
        {
            string resultPhrase = "";
            // Get the sentance that will be searched.
            Console.WriteLine("Please enter the starting sentance:");
            Console.WriteLine("(don't forget your keyword: ie '(Four)')");
            string sentance = Console.ReadLine();
            // Get the search word.
            Console.WriteLine("Please enter the search keyword:");
            string keyword = Console.ReadLine();
            // Set the associated number of words to backwards-iterate.
            int currentNumber = -1;
            try 
            {
                currentNumber = (int)m_Dictionary[keyword.ToLower()];
            }
            catch(KeyNotFoundException ex)
            {
                Console.WriteLine("The provided keyword was not found in the dictionary.");
            }
            // Search the sentance string for the keyword, and get the starting index.
            Console.WriteLine("Searching for phrase...");
            string[] words = sentance.Split(' ');
            int searchResultIndex = -1;
            for (int i = 0; (searchResultIndex == -1 && i < words.Length); i++)
            {
                if (words[i].Equals(keyword))
                {
                    searchResultIndex = i;
                }
            }
            // Handle the search results.
            if (searchResultIndex == -1)
            {
                resultPhrase = "The keyword was not found.";
            }
            else if (searchResultIndex < currentNumber)
            {
                // Check the array boundaries with the given indexes.
                resultPhrase = "Error: Out of bounds!";
            }
            else
            {
                // Get the preceding words.
                for (int i = 0; i < currentNumber; i++)
                {
                    resultPhrase = string.Format(" {0}{1}", words[searchResultIndex - 1 - i], resultPhrase);
                }
            }
            // Display the preceding words.
            Console.WriteLine(resultPhrase.Trim());
            // Exit.
            Console.ReadLine();
        }
