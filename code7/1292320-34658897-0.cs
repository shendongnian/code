    var methodArgumentType = "IDictionary<string, string>";
    if (methodArgumentType.Contains("<") && methodArgumentType.Contains(">"))
    {
      	methodArgumentType = Regex.Replace(methodArgumentType, @"<([^<>]+)>", 
            m => string.Format("<{0}>", m.Groups[1].Value.Replace(",", "#COMMA#")));
    }
    Console.WriteLine(methodArgumentType);
    // => IDictionary<string#COMMA# string>
