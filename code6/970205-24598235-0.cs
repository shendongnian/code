        static void Main(string[] args)
        {
            var t = new List<string>();        // starts with 43 items
            var newText = new List<string>();  // starts with 172 items
            t.AddRange(Enumerable.Range(1, 43).Cast<string>());
            newText.AddRange(Enumerable.Range(1, 172).Cast<string>());
            // add only members t that do not exist in set newText (44..172 added)
            newText.AddRange(t.Except(newText));
        }
