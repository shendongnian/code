    using System;
    using System.Linq;
    namespace TestConsole
    {
       public class StackOverflow
       {
          public void test()
          {
             int senderid = 123456789;
             int receiverid = 123456781;
             Custommer[] cust = new Custommer[]
             {
                new Custommer()
                {
                    ID = 123456789,
                    Name = "John_Sender"
                },
                new Custommer()
                {
                    ID = 123456781,
                    Name = "Bob_Receiver"
                }
             };
             Shipments[] shipments = new Shipments[]
             {
                new Shipments()
                {
                    ID = 150,
                    SenderID = 123456789,
                    ReceiverID = 123456781,
                    ReceivingDate = new DateTime(2016, 09, 01),
                    DeliveryDate = new DateTime(2016, 09, 02),
                    Status = "Delivered"
                },
             };
             ShipmentDetail[] shipmentdetails = new ShipmentDetail[]
             {
                new ShipmentDetail()
                {
                    ShipmentID = 150,
                    Weight = 25.00,
                    Volume = 25.00,
                    Type = "Whatever",
                    Cost = 25.00,
                    Distance = 25.00
                },
             };
            var q1 = from _shipment in shipments
                    join _shipmentdetail in shipmentdetails on _shipment.ID equals _shipmentdetail.ShipmentID
                    where _shipment.SenderID == senderid && _shipment.ReceiverID == receiverid
                    select new
                    {
                        ShipmentID = _shipment.ID,
                        Status = _shipment.Status,
                        SenderID = _shipment.SenderID,
                        SenderName = cust.Where(s => s.ID == _shipment.SenderID).Select(s => s.Name).FirstOrDefault(),
                        ReceiverID = _shipment.ReceiverID,
                        ReceiverName = cust.Where(s => s.ID == _shipment.ReceiverID).Select(s => s.Name).FirstOrDefault(),
                    };
            var q2 = q1.First();
            Console.WriteLine
            (
                "Shipment Id  = " + q2.ShipmentID.ToString() + "\n" +
                "Status = " + q2.Status + "\n" +
                "Sender ID = " + q2.SenderID + "\n" +
                "SenderName = " + q2.SenderName + "\n" +
                "Receiver ID = " + q2.ReceiverID + "\n" +
                "Receiver Name = " + q2.ReceiverName
            );
        }
        public class Custommer
        {
            public int ID;
            public string Name;
        }
        public class Shipments
        {
            public int ID;
            public string Status;
            public int SenderID;
            public int ReceiverID;
            public DateTime ReceivingDate;
            public DateTime DeliveryDate;
        }
        public class ShipmentDetail
        {
            public int ShipmentID;
            public double Weight;
            public double Volume;
            public string Type;
            public double Cost;
            public double Distance;
        }
      }
    }
