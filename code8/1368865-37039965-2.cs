        public static ICollection<Reference> Scan(string text)
        {
            List<Reference> references = new List<Reference>();
            if (text == null)
            {
                return references;
            }
            string[] words = RemoveHtml.Replace(text, "").Split(' ', '(', ')', ';', '\r', '\n', '\t');
            for (int i = 0; i < words.Length; i++)
            {
                string one = words[i];
                // If we are starting with a blank entry, just skip this cycle
                if(string.IsNullOrWhiteSpace(one))
                {
                    continue;
                }
                string two = i + 1 < words.Length ? string.Join(" ", one, words[i + 1]) : one;
                string three = i + 2 < words.Length ? string.Join(" ", two, words[i + 2]) : two;
                Book book;
                bool match = Book.TryParse(one, out book);
                match = match || Book.TryParse(two, out book);
                match = match || Book.TryParse(three, out book);
                if(match)
                {
                    string four = i + 3 < words.Length ? string.Join(" ", three, words[i + 3]) : three;
                    string five = i + 4 < words.Length ? string.Join(" ", four, words[i + 4]) : four;
                    // Keep the most inclusive version of the reference
                    Reference found = null;
                    foreach(string test in new [] {two,three,four,five})
                    {
                        Reference check;
                        if(TryParse(test, out check))
                        {
                            found = check;
                        }
                    }
                    if(found != null && !references.Contains(found))
                    {
                        references.Add(found);
                    }
                }
            }
            return references;
        }
