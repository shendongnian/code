    string cadenaValue = null;
    string hotelValue = null;
    if (node.Attributes != null)
    {
        var cadenaAttribute = node.Attributes["Cadena"];
        if (cadenaAttribute != null) 
            cadenaValue = cadenaAttribute.Value;
        var hotelAttribute = node.Attributs["Hotel"];
        if (hotelAttribute != null)
            hotelValue = hotelAttribute.Value;
    }
    
    if (cadenaValue != null)
    {
        Console.WriteLine(cadenaValue);
    }
    if (hotelValue != null)
    {
        Console.WriteLine(hotelValue);
    }
