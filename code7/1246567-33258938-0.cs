            private static IEnumerable<string> GetEntries(string str)
            {
                List<string> entries = new List<string>();
                StringBuilder entry = new StringBuilder();
                while (str.Length > 0)
                {
                    char ch = str[0];
                    if (ch == ',' && entry.ToString().Contains("@"))
                    {
                        entries.Add(entry.ToString());
                        entry.Clear();
                    }
                    else
                    {
                        entry.Append(ch);
                    }
                    str = str.Remove(0, 1);
                }
    
                return entries;
            }
