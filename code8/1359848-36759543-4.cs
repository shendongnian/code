    var obj = new
    {
        SomeNormalProp = "foo",
        ThisIsSilly1 = 1,
        ThisIsSilly2 = 2,
        ThisIsSilly3 = 3,
        ThisIsSilly4 = 4
    };
    
    dynamic barfObj = new ExpandoObject();
    foreach (var prop in obj.GetType().GetProperties())
        if (prop.Name.StartsWith("ThisIsSilly"))
            //add property dynamically
            ((IDictionary<string, object>)barfObj).Add(prop.Name, prop.GetValue(obj));
    
    //now barfObj is exactly what you want.
    var sampleVal = barfObj.ThisIsSilly1;
    var json = JsonConvert.SerializeObject(barfObj);
