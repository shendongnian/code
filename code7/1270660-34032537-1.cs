    DbContext dbContext = new DbContext();
    List<WorkOrder> workOrders = new List<WorkOrder>();
    List<WorkOrderItem> workOrderItems = new List<WorkOrderItem>();
    foreach (Property property in properties)
    {
        foreach (Vendor vendor in vendors)
        {
            WorkOrder wo = new WorkOrder();
            WorkOrder.PropertyID = property.PropertyID;
            WorkOrder.VendorID = vendor.VendorID;
            dbContext.AddObject(wo);
            workOrders.Add(wo);
        }
    }
            
    dbContext.SaveChanges();
    foreach (WorkOrder wo in workOrders)
    {
        foreach (WorkOrderItemViewModel itemView in workOrderItemViewModels)
        {
            WorkOrderItem item = new WorkOrderItem();
            item.WorkOrderID = wo.WorkOrderID;
            dbContext.AddObject(item);
            workOrderItems.Add(item);
        }
    }
    dbContext.SaveChanges();
    foreach (WorkOrderItem item in workOrderItems)
    {
        foreach (WorkOrderItemCostViewModel costView in workOrderItemCostViewModels)
        {
            WorkOrderItemCost cost = new WorkOrderItemCost();
            cost.WorkOrderItemID = item.WorkOrderItemID;
            dbContext.AddObject(cost);
        }
    }
    dbContext.SaveChanges();
     
