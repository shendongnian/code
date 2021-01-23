    static void Main()
            {
                string filePath = @"C:\yourTextFile.txt";
                string input = File.ReadAllText(filePath);
                string pattern = @"#HEADINGBEGIN#.*?#GROUPEND#";
                var matches = Regex.Matches(input, pattern, RegexOptions.Singleline);
                List<string> list = new List<string>();            
                foreach (var v in matches)
                {
                    list.Add(v.ToString());
                }
                // Now save this list where ever you want.
            }
