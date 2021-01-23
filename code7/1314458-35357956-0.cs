    DataContextDataContext ob = new DataContextDataContext();
    foreach (var emp1 in ob.DimProducts)
    {
        Console.WriteLine(JsonConvert.SerializeObject(emp1, Formatting.Indented));
    }
    foreach (var emp2 in ob.DimProductCategories)
    {
         string jsonEmp2 = JsonConvert.SerializeObject(emp2, Formatting.Indented)
         Console.WriteLine(jsonEmp2);
    }
