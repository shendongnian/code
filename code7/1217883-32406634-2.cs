                List<string> x = new List<string>();
                List<string> newCollection = new List<string>();
                string[] myWords = { "Java have", "CSharp", "OO", "and", "mvc" };
               
                string Text = "Both CSharp and Java have mvc frameworks and are OO languages.";
                string[] splitText = Text.Split(' ');
    
                foreach (string s2 in myWords)
                {
                    string[] b = s2.Split(' ');
                    foreach(string c in b)
                    {
                        x.Add(c);
                    }
                }
    
                foreach (string d in splitText)
                {
                    if (x.Contains(d))
                    {
                        newCollection.Add(d);
                        Console.WriteLine(d);
                    }
    
                }
