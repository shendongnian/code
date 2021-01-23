    async Task YourOriginalFunction(DataTable sap_tickets)
    {
        //Be user System.Data.DataSetExtensions.dll is included in the project refrences 
        //to get AsEnumerable() to work.
        var tasks = sap_tickets.AsEnumerable().Select(BodyAsync)
        await Task.WhenAll(tasks);
    }
    async Task BodyAsync(DataRow row)
    {
        picklist = row["absentry"].ToString();
        try
        {
             //call webservice here
             string response = await Ut.updateFulfilment(row["order_number"].ToString());
        }
        catch (Exception)
        {
            //log error to DB
            Ut.FlagOff(picklist, CommonEnums.FLAG_OFF_TYPE.ERROR.ToString());
        }
    }
