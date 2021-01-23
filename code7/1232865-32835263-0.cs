    IEnumerable<MyCustom> WhereByAge(IEnumerable<MyCustom> source, int age)
    {
        foreach (MyCustom myCustom in source)
        {
            if (myCustom.Age > age)
            {
                yield return myCustom;
            }
        }
    }
