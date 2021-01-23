    // Check if a card was added
    foreach (SubClass1 obj in SubClass1Objs)
        if (!objs.Contains(obj))
            objs.Add(obj);
    // Check if a card has been deleted
    for (int i = 0; i < objs.Where(c => c.GetType() == typeof(SubClass1)).Count(); ++i)
    {
        BaseClass obj = objs.Where(c => c.GetType() == typeof(SubClass1)).ElementAt(i);
        if (!SubClass1Objs.Contains(obj))
            objs.Remove(obj);
    }
    
