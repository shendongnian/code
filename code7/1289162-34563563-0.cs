    var myList = new List<string>() { "a", "1", "b", "2" };
               
    var nonNumericItems = myList.Where(item => !item.Any(i => Char.IsDigit(i)));
    
    var numericItems = myList
            .Select(item => String.Join("", item.Where(Char.IsDigit)))
            .Where(item => !String.IsNullOrEmpty(item));
    
    var result = numericItems
            .Union(nonNumericItems)
            .OrderBy(item=> item);
