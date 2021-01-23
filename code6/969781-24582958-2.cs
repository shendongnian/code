       public static class StringCheck
            {
                public  static string Checker()
                {
                    string str = "Hello# , how are you?";
                    string newstr = null;
                    var regexItem = new Regex("[^a-zA-Z0-9_.]+");
                    if (regexItem.IsMatch(str[str.Length - 1].ToString()))
                    {
                        newstr = str.Remove(str.Length - 1);
                    }
                    string replacestr = Regex.Replace(newstr, "[^a-zA-Z0-9_]+", "-");
                    return replacestr;
                }
            
            }
