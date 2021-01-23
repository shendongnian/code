    var words = message.Split(' ').
                   Where(messagestr => !string.IsNullOrEmpty(messagestr)).
                   GroupBy(messagestr => messagestr).
                   OrderByDescending(groupCount => groupCount.Count()).                 
                   ToList();
    words.ForEach(groupCount => Console.WriteLine("{0}\t{1}", groupCount.Key, groupCount.Count()));   
   
