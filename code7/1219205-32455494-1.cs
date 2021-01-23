    public class TimeTotalsResponseSerializer : IXmlSerializable
    {
        public TimeTotalsResponse Response { get; set; }
        public void ReadXml(XmlReader reader)
        {
            Response = new TimeTotalsResponse();
            Response.TimeTotal = new TimeTotal();
            reader.ReadToDescendant("total-mins-sum");
            Response.TimeTotal.TotalMinsSum = reader.ReadElementContentAsDouble();
            Response.TimeTotal.NonBilledMinsSum = reader.ReadElementContentAsDouble();
            Response.TimeTotal.NonBillableHoursSum = reader.ReadElementContentAsDouble();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void WriteXml(XmlWriter writer)
        {
        }
    }
