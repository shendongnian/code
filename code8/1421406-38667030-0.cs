    public static List<ItemDeliveryInfo> GetItemDeliveryInfo(List<ItemDeliveryAudits> audits) {
       var list = new List<ItemDeliveryinfo>();
       foreach (var deliveryAudit in audits)
       {
           list.Add(new ItemDeliveryInfo(deliveryAudit));
       }
    }
