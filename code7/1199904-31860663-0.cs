    List<string> names = new List<string>();
    Type t = typeof(Trim);
    var methods = t.GetMethods(BindingFlags.Static | BindingFlags.Public);
    
    foreach (var method in methods)
    {
       string name = method.Name;
       names.Add(name);
    }
