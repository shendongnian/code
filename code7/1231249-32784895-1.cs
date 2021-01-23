    var yourString = @"ls 0 
            [0,86,180]
            ls 1 
            [1,2,200]
            ls 2 
            [2,3,180]
            ls 3 
            [3,4,234]";
    var result = yourString.Split(new char[] { '\n' })                //split
                           .Where(i => i.Contains('['))               //filter
                           .Select(i => i.Replace("[", string.Empty)  //prepare
                                         .Replace("]", string.Empty))
                           .ToList();
    var newArray = string.Join(",", result);                          //merge the result
