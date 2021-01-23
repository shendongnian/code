    Plan b = new Plan();
    Type t = new Type(b.GetType());
    var properties = t.GetProperties();
    for(int index = 0; index < properties.Length; index++)
    {
        properties[index].SetValue(b, 100);  
    }
