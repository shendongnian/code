    public class Datum
    {
        public string mod_id { get; set; }
        public string sub_mod { get; set; }
        public string version { get; set; }
        public DateTime upload_date { get; set; }
    }
    public class sy_periode
    {
        public string table { get; set; }
        public int effected { get; set; }
        public IList<Datum> data { get; set; }
    }    
