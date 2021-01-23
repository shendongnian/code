    foreach (JProperty property in pin.Properties()) 
    {
        if (string.IsNullOrWhiteSpace(property.Value)) 
        {
            throw new Exception("Some exception");
            //Or perform count for minimum/maximum check 
        }
    }
