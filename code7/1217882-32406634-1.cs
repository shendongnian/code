            List<string> newCollection = new List<string>();
            string[] myWords = { "Java", "CSharp", "OO", "and", "mvc" };
            string Text = "Both CSharp and Java have mvc frameworks and are OO languages.";
            string[] splitText = Text.Split(' ');
            foreach(string s in splitText)
            {
                if (myWords.Contains(s))
                    newCollection.Add(s);
            }
    
    
