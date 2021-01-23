    foreach (var property in properties)
    {
        var propertyType = property.PropertyType;
        var value = property.GetValue(myInvoice);
        if (value != null)
        {
            if (propertyType.IsGenericParameter)
            {
                //Have Generic parameters
            }
            else
            {
                //How I Know if my class == person
                if(propertyType.Name == "Person" && propertyType = typeof(Customer)){
                    // class == person
                }   
            }
        }
    }
