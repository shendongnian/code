    var groups = from bar in bars
                 from datum in rawData
                 where bar.FallsWithin(datum)
                 group datum by bar into g
                 select new
                 { 
                     Mid = (bar.lowSide  + bar.highSide) / 2,
                     Count = g.Count()
                 };
    // Write a similar extension of SortedDictionary / SortedList if needed.
    // Note: this will blow up if two bars have the same Mid.
    // Note 2: A dictionary with a double as the key isn't the best idea.
    var result = groups.ToDictionary(a => a.Mid, a => a.Count);  
