    Square test = new Square();
    test.Field1 = "sdflsjf";
    test.Field2 = "sdlfksj";
    test.Field3 = "sldfjs";
    
    foreach (PropertyInfo propertyInfo in test.GetType().GetProperties())
    {
        if (propertyInfo.Name == "Field2")
            propertyInfo.SetValue(test, "checked");
    
    }
