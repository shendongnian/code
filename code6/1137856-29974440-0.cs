    var processed = File.ReadLines(@"myFilePath.txt")
    	.SelectMany((line, lineNumber) => line.Split().Select(word => new{word, lineNumber}))
    	.GroupBy(x => x.word)
    	.Select(g => new{
            Count = g.Count(), 
            Word = g.Key, 
            Positions = g.Select(x => x.lineNumber)});
    
    foreach(var entry in processed)
    {
    	Console.WriteLine("{0} {1} {2}",
                          entry.Count,
                          entry.Word,
                          string.Join(" ",entry.Positions));
    }
