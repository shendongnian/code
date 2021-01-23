    static async Task GetPurchaseOrders(string supplier)
    {
        try
        {
            var purchaseOrders = await VNA.PurchaseOrders.ForSupplierAsyncTask(supplier);
    
            foreach (var order in purchaseOrders)
            {
                CreateXMLDocument(order, order.orderNbr, "PurchaseOrder");
            }
        }
        catch (Exception ex)
        {   // <-- Place a breakpoint here...
            // I would imagine you're getting an exception
        }
    }
