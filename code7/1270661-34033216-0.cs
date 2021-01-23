        foreach (Vendor vendor in vendors)
        {
             WorkOrder wo = new WorkOrder();
             WorkOrder.PropertyID = property.PropertyID;
             WorkOrder.VendorID = vendor.VendorID;
             dbContext.AddObject(wo);
             foreach (WorkOrderItemViewModel itemView in workOrderItemViewModels)
             {
                 WorkOrderItem item = new WorkOrderItem();
                 item.WorkOrderID = wo.WorkOrderID;
                 dbContext.AddObject(item);
                 foreach (WorkOrderItemCostViewModel costView in workOrderItemCostViewModels) 
                 {
                     WorkOrderItemCost cost = new WorkOrderItemCost();
                     cost.WorkOrderItemID = item.WorkOrderItemID;
                     dbContext.AddObject(cost);
                 }
             }
         }
    }
    dbContext.SaveChanges();
