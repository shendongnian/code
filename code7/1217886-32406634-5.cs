    List<string> newCollection = new List<string>();
    string[] myWords = { "Java have", "CSharp", "OO", "and", "mvc" };
    
    string Text = "Both CSharp and Java have mvc frameworks and are OO languages.";
                
    string[] splitText = Text.Split(' ');
    
    List<string> x = SplitArray(myWords);
    
    foreach (string d in splitText)
    {
        if (x.Contains(d))
        {
            newCollection.Add(d);
            Console.WriteLine(d);
        }
    
    }
