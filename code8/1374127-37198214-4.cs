    var x = typeof(B).GetProperties();
    foreach (PropertyInfo i in x)
    {
        if (i.DeclaringType == typeof(B))
        {
            Console.WriteLine(i.Name);
        }
    }
