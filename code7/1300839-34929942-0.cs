    //Loop through objects
    foreach(IMS_Product prod in newrec) 
    {
        //Loop through properties
        foreach (var prop in typeof(IMS_Product).GetProperties()) 
        {
             //Print property name
             Console.WriteLine(prop.Name);
             
             //Print property value
             Console.WriteLine(prop.GetValue(prod));
        }
    }
