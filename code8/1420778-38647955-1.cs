    foreach (var property in properties)
    {
        var propertyType = property.PropertyType;
        var value = property.GetValue(myInvoice);
        if (value != null)
        {                
            if(value is Customer) {
                // class == person
                var person = value as Customer;
                var name = person.Name;
            }
        }
    }
