    if(!TryGetProperty(props, "primary site owner", out owner))
    {
    	Console.WriteLine("Error with site owner");
    }
    
    if(!TryGetProperty(props, "primary site owner email", out ownerEmail))
    {
    	Console.WriteLine("Error with site owner email");
    }
