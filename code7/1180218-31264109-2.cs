    string pattern = @"([^\s])([A-Z]+[a-z]*)";
    string replacement = "$1 $2";            
    Console.WriteLine(Regex.Replace("CustomerName", pattern, replacement)); // Customer Name
    Console.WriteLine(Regex.Replace("CustomerID", pattern, replacement)); // Customer ID
    Console.WriteLine(Regex.Replace("CustomerName CustomerID", pattern, replacement)); // Customer Name Customer ID
