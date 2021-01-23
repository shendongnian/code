    var myList = new List<string>() { "a", "1", "b", "2", "123", "cd", "12346", "657" };
               
    var nonNumericItems = myList.Where(item => !item.Any(i => Char.IsDigit(i)))
            .OrderBy(item => item);
    
    var numericItems = myList
            .Select(item => String.Join("", item.Where(Char.IsDigit)))
            .Where(item => !String.IsNullOrEmpty(item))
            .Select(item => Convert.ToInt32(item))
            .OrderBy(item => item)
            .Select(item => item.ToString());
    
    var result = numericItems
            .Union(nonNumericItems);
    result.ToList()
          .ForEach(Console.WriteLine);
