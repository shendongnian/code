    var client = new HttpClient();
    var data = client.GetStringAsync("http://my.yrc.com/dynamic/national/servlet?CONTROLLER=com.rdwy.ec.rextracking.http.controller.PublicTrailerHistoryAPIController&xml=Y&PRONumber=82040X,03117X").Result;
    var ser = new XmlSerializer(typeof(Shipments));
    var t = (Shipments)ser.Deserialize(new StringReader(data));
    public class Shipment
    {
        public string returnCode { get; set; }
        public string returnMessage { get; set; }
        public string freightBillNumber { get; set; }
        //props
    }
    [XmlRoot(ElementName = "SHIPMENTS")]
    public class Shipments
    {
        [XmlElement(ElementName = "SHIPMENT")]
        public List<Shipment> SHIPMENT { get; set; }
    }
