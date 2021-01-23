    var baseClass = new BaseClass();
    var type1 = new TypeOneAditionalInformation();
    var type2 = new TypeTwoAditionalInformation();
    baseClass.FirstName = "Joe";
    baseClass.LastName = "Miller";
            
    type1.FirstName = "Rachel";
    type1.LastName = "Miller";
    type1.X1 = "72";
            
    type2.FirstName = null;
    type2.LastName = "Miller";
    type2.X4 = "99";
            
    var list = new List<BaseClass> {baseClass, type1, type2};
    foreach (BaseClass obj in list)
    {
        Console.WriteLine();
        // Here is where polymorphism is magic!
        obj.TypeTest();
        Console.WriteLine();
    }
