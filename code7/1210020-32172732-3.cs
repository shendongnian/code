        var customer = new CustomerEntity(LastName, FirstName)
        { 
            Email = Email,
            CellPhoneNumber = cellPhoneNumber,
            Optional1 = optional1,
            Optional2 = optional2,
        }
    
        TableOperation insertOperation = TableOperation.Insert(customer);
        TableName.Execute(insertOperation);
