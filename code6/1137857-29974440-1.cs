    var processed =
      //get the lines of text as IEnumerable<string> 
      File.ReadLines(@"myFilePath.txt")
        //get a word and a line number for every word
    	.SelectMany((line, lineNumber) => line.Split().Select(word => new{word, lineNumber}))
        //group words and lines by word
    	.GroupBy(x => x.word)
        //select what you need
    	.Select(g => new{
            //number of words in the group
            Count = g.Count(), 
            //the actual word
            Word = g.Key, 
            //the line number of each instance of the word in the group
            Positions = g.Select(x => x.lineNumber)});
    
    foreach(var entry in processed)
    {
    	Console.WriteLine("{0} {1} {2}",
                          entry.Count,
                          entry.Word,
                          string.Join(" ",entry.Positions));
    }
