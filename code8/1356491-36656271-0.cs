    foreach (var car in carList)
    {  
        foreach (PropertyInfo prop in car.GetType().GetProperties())
        {
             var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
             if (type == typeof (DateTime))
             { 
                 Console.WriteLine(prop.GetValue(car, null).ToString());
             }
        }
    }
