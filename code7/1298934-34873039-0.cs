    public class SalesDetails
    {
        public string Uid {get;set;}
        public string Name {get;set;}
        public List<SalesItem> SalesItems {get;set;} = new List<SalesItem>();
    }
