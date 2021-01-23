        public static string removeDuplicateCharacters(string text, int allowedDuplicates)
        {
            var frequency = new Dictionary<char, int>();
            StringBuilder output = new StringBuilder();
            foreach (char c in text)
            {
                int count = 1;
                if (frequency.ContainsKey(c))
                    count = ++frequency[c];
                else
                    frequency.Add(c, count);
                if (count <= allowedDuplicates)
                    output.Append(c);
            }
            return output.ToString();
        }
 
