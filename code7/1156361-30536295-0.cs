    List<Type> theList = new List<Type>();
    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    {
        theList.AddRange(
            a.GetTypes()
               .Where(t =>     
                   t.Namespace.Equals("foo.test", StringComparison.CurrentCultureIgnoreCase))
               .ToList());
    }
