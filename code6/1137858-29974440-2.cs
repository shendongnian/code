    var processed =
      //get the lines of text as IEnumerable<string> 
      File.ReadLines(@"myFilePath.txt")
        //get a word and a line number for every word
        //so you'll have a sequence of objects with 2 properties
        //word and lineNumber
    	.SelectMany((line, lineNumber) => line.Split().Select(word => new{word, lineNumber}))
        //group these objects by their "word" property
    	.GroupBy(x => x.word)
        //select what you need
    	.Select(g => new{
            //number of objects in the group
            //i.e. the frequency of the word
            Count = g.Count(), 
            //the actual word
            Word = g.Key, 
            //a sequence of line numbers of each instance of the 
            //word in the group
            Positions = g.Select(x => x.lineNumber)});
    
    foreach(var entry in processed)
    {
    	Console.WriteLine("{0} {1} {2}",
                          entry.Count,
                          entry.Word,
                          string.Join(" ",entry.Positions));
    }
