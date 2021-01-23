    DataTable invoicesDataTable = null;
    try
    {
    	invoicesDataTable = GetInvoiceIds();
    }
    catch (Exception ex)
    {
    }
    
    //new work here
    var uniqueCountryCustomer = 
    	invoicesDataTable
    	.AsEnumerable()
    	.GroupBy(row => new
    	{
    		Department = (string)row["Department"], 
    		Attorney = (string)row["MatterNumber"], 
    		MatterNo = (string)row["CUSTOMERNAME"]
    	});
    
    foreach(var customerGroup in uniqueCountryCustomer)
    {
    	foreach(var row in customerGroup)
    	{
    		//now do work on each of these rows from the group
    	}
    }
