            private static IEnumerable<string> GetEntries(string str)
            {
                List<string> entries = new List<string>();
                StringBuilder entry = new StringBuilder();
                while (str.Length > 0)
                {
                    char ch = str[0];
                    //If the first character on the string is a comma, and the entry already contains na '@'
                    //Add this entry to the entries list and clear the temporary entry item.
                    if (ch == ',' && entry.ToString().Contains("@"))
                    {
                        entries.Add(entry.ToString());
                        entry.Clear();
                    }
                    //Just add the chacacter to the temporary entry item, otherwise.
                    else
                    {
                        entry.Append(ch);
                    }
                    str = str.Remove(0, 1);
                }
                //Add the last entry, which is still in the buffer because it doesn't end with a ',' character.
                entries.Add(entry.ToString());
                return entries;
            }
