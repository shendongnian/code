    private void Input_ListTokens(string filterType, string filterValue)
    {
       var type = typeof(IToken);
       var comparison = StringComparison.InvariantCultureIgnoreCase;
       var property = type.GetProperties().FirstOrDefault(p => 
          p.PropertyType == typeof(string) && p.Name.Equals(filterType, comparison));
       if (property == null)
           return;
       var result = Tokens.Where(t => 
           filterValue.Equals((string)property.GetValue(t), comparison));
       foreach (var item in result)
           Console.WriteLine(item);
    }
