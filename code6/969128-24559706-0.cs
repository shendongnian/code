    public class StackOverflow_24559375
    {
        const string XML = @"<?xml version=""1.0""?>
            <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
              <s:Body>
                <ShipNo_Check xmlns=""http://bimgewebservices.gmb.gov.tr"">          
                  <shipNo>13343100VB0000000014</shipNo>
                  <harborNo>1234567</harborNo>
                </ShipNo_Check>
              </s:Body>
            </s:Envelope>";
        [DataContract(Name = "ShipNo_Check", Namespace = "http://bimgewebservices.gmb.gov.tr")]
        public class ShipNo_Check
        {
            [DataMember(Name = "shipNo", Order = 1)]
            public string ShipNo { get; set; }
            [DataMember(Name = "harborNo", Order = 2)]
            public string HarborNo { get; set; }
        }
        public static void Test()
        {
            using (var reader = XmlReader.Create(new StringReader(XML)))
            {
                Message m = Message.CreateMessage(reader, int.MaxValue, MessageVersion.Soap11);
                var body = m.GetBody<ShipNo_Check>();
                Console.WriteLine(body.ShipNo + " - " + body.HarborNo);
            }
        }
    }
