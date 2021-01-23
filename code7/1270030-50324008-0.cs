        public int GetUniqueWordsCount(string txt)
        {
            // Use regular expressions to replace characters
            // that are not letters or numbers with spaces.
            txt = new Regex("[^a-zA-Z0-9]").Replace(txt, " ");
            // Split the text into words.
            var words = txt.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // Use LINQ to get the unique words.
            var wordQuery = words.Distinct();
            return wordQuery.Count();
            //If you want words
            //return word_query.ToArray();
        }
