    var srt = "\"1\":\"120\",\"4\":\"23\",\"6\":\"12\",\"8\":\"120\",\"9\":\"100\"";
    
    srt.Split(',')
        .Select(x => x.Split(':'))
        .ToDictionary(x => int.Parse(x[0].Replace("\"","")), x => int.Parse(x[1].Replace("\"","")))
    
    
    /*
        Output: 
        Dictionary<int, int>(5) 
        { 
            { 1, 120 }, 
            { 4, 23 }, 
            { 6, 12 }, 
            { 8, 120 }, 
            { 9, 100 } 
        }
    */
