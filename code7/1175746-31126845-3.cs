        private static void Main(string[] args)
        {
            
            string input = "123466265.123";
            // take decimal part of input. convert it to word. add it at the end of method.
            string decimals = "";
            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".") + 1);
                // remove decimal part from input
                input = input.Remove(input.IndexOf("."));
            }
            // Convert input into words. save it into strWords
            string strWords = GetWords(input);
            
            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                strWords += " Point " + GetWords(decimals);
            }
            Console.WriteLine(strWords);
        }
        private static string GetWords(string input)
        {
            // these are seperators for each 3 digit in numbers. you can add more if you want convert beigger numbers.
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };
            // Counter is indexer for seperators. each 3 digit converted this will count.
            int i = 0;
            string strWords = "";
            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. if there is not 3 numbers just use take it.
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                // remove the 3 last digits from input. if there is not 3 numbers just remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);
                int no = int.Parse(_3digits);
                // Convert 3 digit number into words.
                _3digits = GetWord(no);
                // apply the seperator.
                _3digits += seperators[i];
                // since we are getting numbers from right to left then we must append resault to strWords like this.
                strWords = _3digits + strWords;
                // 3 digits converted. count and go for next 3 digits
                i++;
            }
            return strWords;
        }
        // your method just to convert 3digit number into words.
        private static string GetWord(int no)
        {
            string[] Ones =
            {
                "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
                "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
            };
            string[] Tens = {"Ten", "Twenty", "Thirty", "Fourty", "Fift", "Sixty", "Seventy", "Eighty", "Ninty"};
            string word = "";
            if (no > 99 && no < 1000)
            {
                int i = no/100;
                word = word + Ones[i - 1] + " Hundred ";
                no = no%100;
            }
            if (no > 19 && no < 100)
            {
                int i = no/10;
                word = word + Tens[i - 1] + " ";
                no = no%10;
            }
            if (no > 0 && no < 20)
            {
                word = word + Ones[no - 1];
            }
            return word;
        }
