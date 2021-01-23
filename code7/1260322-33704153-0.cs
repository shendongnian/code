    public static void CompareObjects(object obj1, object obj2)
    {
        if (obj1.GetType() != obj2.GetType())
        {
            return;
        }
        foreach (var property in obj1.GetType().GetProperties())
        {
            ...
