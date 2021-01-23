    Type myEnumType = typeof(MyEnum);
    var enumValues = Enum.GetValues(myEnumType).Cast<MyEnum>().ToArray();
    var enumNames = Enum.GetNames(myEnumType);
    int[] enumPositions = Array.ConvertAll(enumNames, n => 
    {
        OrderAttribute orderAttr = (OrderAttribute)myEnumType.GetField(n)
            .GetCustomAttributes(typeof(OrderAttribute), false)[0];
        return orderAttr.Pos;
    });
    SortByKeys(enumPositions, enumValues); // Sorted values
    SortByKeys(enumPositions, enumNames);  // Sorted names
