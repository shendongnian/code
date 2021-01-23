    string str = @"Hi, how are you. hope are you doing good &amp; &yen; whatis goind on &lessthan;and";
                MatchCollection matches = Regex.Matches(str, @"\b(?!&)[a-zA-Z]+(?!;)\b");
                
                foreach (Match m in matches)
                {
                    string oldWord = m.ToString();
                    str = Regex.Replace(str, oldWord, Regex.Replace(m.ToString(), @".", "z"));
                   
                }
                Console.WriteLine(str);
