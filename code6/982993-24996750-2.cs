    List<string> words = new List<string> { "PlusContent", "PlusArchieve", "PlusContent1", "PlusArchieve1" };
            foreach (string tester in words)
            {
                Regex r1 = new Regex(@"\bPlus\D+(\d*)", RegexOptions.IgnoreCase);
                foreach (Match m in r1.Matches(tester))
                {
                    //Console.WriteLine(m);
                    if (!string.IsNullOrEmpty(Regex.Replace(tester, @"\bPlus\D+(\d*)", "$1")))
                        Console.WriteLine(Regex.Replace(tester, @"\bPlus\D+(\d*)", "$1"));
                }
            }
