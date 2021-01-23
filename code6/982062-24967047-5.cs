    ...
    if (pi.Name == PropertyName)
    {
        var value = 
            myObject.GetType()
                    .GetProperty("inobjects")
                    .GetValue(myObject, null);
    
        s = (string) pi.GetValue(value, null);
    }
