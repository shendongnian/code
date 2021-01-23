    usersQuery
        .Where(u => new Property { Value = new StringPropertyValue {
                StringValue = u.FirstName
            }}.Value.StringValue == "John")
        .Where(u => new Property { Value = new BoolPropertyValue { 
                BoolValue = u.IsArchived
            }}.Value.BoolValue == true);
