    string before_split = "pune,mumbai|01234,delhi|65432,Bhopal|09231,jabalpur|0987765";
    
    var firstPart = before_split.Substring(0, before_split.IndexOf(",", System.StringComparison.Ordinal));
    var stringToProcess = before_split.Substring(before_split.IndexOf(",", System.StringComparison.Ordinal) + 1);
    var stringSegments = stringToProcess.Split(',');
    
    Console.WriteLine("{0},{1}",firstPart ,stringSegments[0]);
    
    for (var i = 1; i < stringSegments.Length; i++)
    {
    	Console.WriteLine(stringSegments[i]);
    }
