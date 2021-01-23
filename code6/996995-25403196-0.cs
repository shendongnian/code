    public int? GetSomeId(object obj) {
        Class1 class1 = obj as Class1;
        if (class1 != null)
        {
            return class1.SomeProperty != null ? class1.SomeProperty.Id : (int?)null;
        }
        Class2 class2 = obj as Class2;
        if (class2 != null)
        {
            return class2.AnotherProperty != null ? class2.AnotherProperty.AnotherId : (int?)null;
        }
        ....
        return null;
    }
