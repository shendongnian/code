    public class Data1
    {
        public string Campionato { get; set; }
        public string Data { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public int HSFT { get; set; }
        public int ASFT { get; set; }
        public int HSHT { get; set; }
        public int HSHT2 { get; set; }
    }
    public class Data2 //you can use inheritance and reduce duplication of properties
    {
        public string Data { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public double HODD { get; set; }
        public double AODD { get; set; }
        public double XODD { get; set; } //no name in sample
    }
    public class CombinedData //you can use inheritance here too
    {
        public string Campionato { get; set; }
        public string Data { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }
        public int HSFT { get; set; }
        public int ASFT { get; set; }
        public int HSHT { get; set; }
        public int HSHT2 { get; set; }
        public double HODD { get; set; }
        public double AODD { get; set; }
        public double XODD { get; set; } //some name
    }
