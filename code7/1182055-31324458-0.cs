            public static string RemoveDuplicateCharacters(string text, int allowedDuplicates)
            {
                var seen = new Dictionary<char, int>();
                var sb = new StringBuilder();
    
                foreach (char c in text)
                {
                    int count;
                    if (seen.TryGetValue(c, out count))
                    {
                        count++;
                    } else
                    {
                        count = 1;
                    }
    
                    seen[c] = count;
    
                    if (count <= allowedDuplicates)
                        sb.Append(c);
                }
    
                return sb.ToString();
            }   
