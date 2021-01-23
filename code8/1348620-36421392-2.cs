    var s = @"Lngton KY 40511 ARRIER — LEAVE IF NO RESPONSE LODRESS SERVICE REQUESTED
    
    604159595920
    
    YAWAR MUHAMMAD YOUNUS
    
    1263 S CHILLICOTHE RD STE
    
    AURORA OH 43192—8552 695—81";
    var res = s.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries) // Split into lines (you already have it)
                 .SkipWhile(p => !(p.Trim().Length == 12 && p.Trim().All(m => Char.IsDigit(m))))
                 .Skip(1)
                 .Take(1)
                 .FirstOrDefault();
    if (!string.IsNullOrWhiteSpace(res))
        Console.WriteLine(res);
