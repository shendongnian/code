        public static string Replace(string input)
        {
            //A list of updated digits so we don't need to
            //call string.Replace for one digit twice
            List<char> updatedDigits = new List<char>();
            //An array of char to check the input
            char[] inputCharArr = input.ToCharArray();
            foreach (var c in inputCharArr)
            {
                //If we never updated this digit
                if (!updatedDigits.Contains(c))
                {
                    //If the digit was a number ([0-9] are [48-57] in unicode)
                    if ((int)c >= 48 && (int)c <= 57) 
                    {
                        //Replace the old char with the new char
                        //(8272 when added to the unicode of [0-9] gives the desired result)
                        input = input.Replace(c, (char)((int)c + 8272));
                        updatedDigits.Add(c);
                    }
                }
            }
            return input;
        }
