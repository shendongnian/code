        **Yes You Can do this by Add two more field in your Shipments model.
        SenderName ,ReceiverName**
        
        if Your Model.Shipments have not SenderName and ReceiverName in Database,
        Than You Need to Create Class for Shipment Reference 
        Ex 
    
        public class ShipmentView
    {
    public int Id{get;set;}
    public bool Status{get;set;}
    public double Cost{get;set;}
    public string Type{get;set;}
    public string ReceiverName{get;set;}
    public string SenderName{get;set;}
    }
        
        
        
            select new ShipmentView()
            >                     {
            >                        Id = shipments.ID,
            >                        Status = shipments.Status,
            >                        SenderTCID = shipments.SenderTCID,
                                     SenderName = (from sendername in model.Sender where sendername.SenderId == shipments.SenderId select sendername).single().SenderName, 
            ReceiverName = (from receivername in model.Receiver where receivername.ReceiverId == shipments.ReceiverId select receivername).single().ReceieverName, 
            >                         shipments.ReceiverTCID,
            >                         shipments.ReceivingDate,
            >                         shipments.DeliveryDate,
            >                         shipmentdetails.Weight,
            >                         shipmentdetails.Volume,
            >                         shipmentdetails.Type,
            >                         shipmentdetails.Cost,
            >                         shipmentdetails.Distance,
            >                     };
