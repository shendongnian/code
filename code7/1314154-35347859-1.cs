    //Root Class
    public class Flight
    {
        public string begin_date { get; set; }
        public string end_date { get; set; }
        public string query_type { get; set; }
        public IList<Sorty> sorties { get; set; } //Bam.. how it works
        public string sum_dt { get; set; }
        public string first_tkof { get; set; }
        public string last_ldg { get; set; }
        public int max_dalt { get; set; }
    }
    //That list contains populated objects of this Sorty class
    public class Sorty
    {
        public string id { get; set; }
        public string cs { get; set; }
        public string launch { get; set; }
        public string tow_id { get; set; }
        public string tow_name { get; set; }
        public int type { get; set; }
        public string date { get; set; }
        public Tkof tkof { get; set; }
        public Ldg ldg { get; set; }
        public string dalt { get; set; }
        public string dt { get; set; }
    }
