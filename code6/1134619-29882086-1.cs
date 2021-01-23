    ItemProperties prop;
    try
    {
    	prop.Quantity = Convert.ToInt32(stringVar);
    }
    catch(FormatException)
    {
    	// error handling
    }
