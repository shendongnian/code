    var ponum = dtPurchaseOrder.Columns.Add("PONumber");
    var cust = dtPurchaseOrder.Columns.Add("Customer");
    var address = dtPurchaseOrder.Columns.Add("Address");
    
    
    dtPurchaseOrder.PrimaryKey =  new[] {ponum, cust, address};
    
    dt.Rows.Add("PO123456", "MH", "123");
    dt.Rows.Add("PO654321", "AB", "123");
    dt.Rows.Add("PO654321", "AB", "123");
    
    
    foreach (DataRow r in dt.Rows)
    {
    	var exisiting = dtPurchaseOrder.Rows.Find(r.ItemArray);
    	
    	if (exisiting == null)	
    	{
    		dtPurchaseOrder.Rows.Add(r.ItemArray);
    	}		
    }	
