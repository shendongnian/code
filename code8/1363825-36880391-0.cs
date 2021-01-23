    public static string[] GetTranslation(string phraseIn)
            {
                string vow = "aeiouyAEIOUY";
                var splitted = phraseIn.Split(new[] {" "}, StringSplitOptions.None);
                List< string> ret = new List<string>();
                foreach (string split in splitted)
                {
                    string vows = string.Empty;
                    string cons = string.Empty;
                    for (var i = 0; i < split.Length; i++)
                    {
                        char ch = split[i];
                        if (vow.Contains(ch))
                        {
                            vows += ch;
                        }
                        else
                        {
                            cons += ch;
                        }
                    }
                    ret.Add(cons + vows + "ay");
                }
    
    
                return ret.ToArray();
            }
