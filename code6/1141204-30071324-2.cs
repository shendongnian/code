    AxaptaRecord axRecord;
    try
    {
        // Login to Microsoft Dynamics AX.
        ax = new Axapta();
        ax.Logon(null, null, null, null);
        // Create a new AddressState table record.
        using (axRecord = ax.CreateAxaptaRecord("TableName"))
        {
            // Provide container for record field.
            AxaptaContainer axContainer = ax.CreateAxaptaContainer();
            axContainer.Add("Some Data");
            axRecord.set_Field("ContainerField", axContainer);
            
            // Other fields
        
            // Commit the record to the database.
            axRecord.Insert();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error encountered: {0}", e.Message);
        // Take other error action as needed.
    }
