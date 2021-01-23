    public class LandRootObject
    {
        public int page { get; set; }
        public int pages { get; set; }
        public string per_page { get; set; }
        public int total { get; set; }
    }
    public class LandBodyObject
    {
        public string id { get; set; }
        public string iso2Code { get; set; }
        public string name { get; set; }
        public Region region { get; set; }
        public Adminregion adminregion { get; set; }
        public Incomelevel incomeLevel { get; set; }
        public Lendingtype lendingType { get; set; }
        public string capitalCity { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
    public class Region
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class Adminregion
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class Incomelevel
    {
        public string id { get; set; }
        public string value { get; set; }
    }
    public class Lendingtype
    {
        public string id { get; set; }
        public string value { get; set; }
    }
