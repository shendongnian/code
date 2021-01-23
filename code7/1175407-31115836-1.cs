    // get all get methods of all public properties
    var getter = typeof(MyObject).GetProperties().Select(prop => prop.GetMethod).ToList();
    
    // sort by number of matches
    var result = list.OrderBy(l => getter.Count(a => a.Invoke(l, null).Equals(a.Invoke(testObject, null)))).LastOrDefault();
