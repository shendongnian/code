    var words = message.Split(' ').
                   Where(messagestr => !string.IsNullOrEmpty(messagestr)).
                   GroupBy(messagestr => messagestr).
                   OrderByDescending(groupCount => groupCount.Count()).                 
                   ToList();
    var w = words.SelectMany(x => x.Distinct()).ToList(); //Add this line to get all the words in an array
    words.ForEach(groupCount => Console.WriteLine("{0}\t{1}", groupCount.Key, groupCount.Count()));    
