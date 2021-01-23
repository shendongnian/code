    Regex myreg = new Regex(@"<w+>");
    
    string contents = File.ReadAllText("mad.txt"); 
    string modifiedContents = contents;
    
    Match m = myreg.Match(contents);   // m is the first match
    while (m.Success)
    {
         Console.Write("Please type in " + m.Value.Replace("<", "").Replace(">", "") + ": ");
         string place = Console.ReadLine();
    
         modifiedContents = myreg.Replace(contents, m.Value, place, 1);
    
         m = m.NextMatch();  
    }
