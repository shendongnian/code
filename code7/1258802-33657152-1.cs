    //Class for "distance" and "duration" which has the "text" and "value" properties.
    public class CepElementNode
    {
        public string text { get; set; }
        public string value { get; set; }
    }
    //Class for "distance", "duration" and "status" nodes of "elements" node 
    public class CepDataElement
    {
        public CepElementNode distance { get; set; }
        public CepElementNode duration { get; set; }
        public string status { get; set; }
    }
    //Class for "elements" node
    public class CepDataRow
    {
        public List<CepDataElement> elements { get; set; }
    }
    //Class which wrap the json response
    public class RequestCepViewModel
    {
        public List<string> destination_addresses { get; set; }
        public List<string> origin_addresses { get; set; }
        public List<CepDataRow> rows { get; set; }
        public string status { get; set; }
    }
