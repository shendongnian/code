    public class OrdersContainer : IXmlSerializable
    {
        public Order[] Orders;
        public void WriteXml(XmlWriter writer)
        {
            // Serialize other properties
            writer.WriteStartElement("Orders");
            var ser = new XmlSerializer(typeof(Order));
            for(var i = 0; i < Orders.Length; i++)
            {
                Orders[i].Sequence = (i + 1).ToString();
                ser.Serialize(writer, Orders[i]);
            }
            writer.WriteEndElement(); // Orders
        }
        // ...
    }
