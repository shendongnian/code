    public static class Global 
    {
            /// <summary>
            /// Returns a list of bad words found in the string based
            /// on spanish and english "bad words"
            /// </summary>
            /// <param name="str">the string to check</param>
            /// <returns>list of bad words found in string (if any)</returns>
            public static string[] CheckForBadWords(string str)
            {
                var badWords = GetBadWords();
                var badWordsCaught = new List<string>();
    
                if (badWords.Any(str.ToLower().Contains))
                {
                    badWordsCaught = badWords.Where(x => str.Contains(x)).ToList();
                }
    
                return badWordsCaught.ToArray();
            }
    
        /// <summary>
        /// Retrieves a list of "bad words" from the text file. Words include
        /// both spanish and english
        /// </summary>
        /// <returns>strings of bad words</returns>
        private static List<string> GetBadWords()
        {
            var badWords = new List<string>();
            string fileName = string.Format("{0}/Content/InvalidWords.txt", AppDomain.CurrentDomain.BaseDirectory);
            if (System.IO.File.Exists(fileName))
            {
                badWords = System.IO.File.ReadAllLines(fileName).ToList();
            }
            return badWords.ConvertAll(x => x.ToLower());
        }
    }
