     static bool isAnagrams(string str1,string st)
            {
                string str1 = "reaad";
                string str2 = "Daaer";
                char[] t = str1.ToCharArray();
                var kt = t.Distinct();
                string pattern = @"e";
                // Create a Regex  
                Regex rg = new Regex(pattern);
                Console.WriteLine(rg.Match(str1).Value);
                foreach (var item in kt)
                {
                    string pat = item.ToString();
                    Regex r = new Regex(pat,RegexOptions.IgnoreCase);
                    if (r.Matches(str1).Count != r.Matches(str2).Count)
                    {
                        return false;
                    }
                }
                return true;
            }
