    public class AssigmentViewModel
    {
        public int ID { get; set; }    
        public int TypeId { get; set; }    
        public decimal? weight { get; set; }
        public decimal? dose { get; set; }
        public decimal? inADay { get; set; }
        [DataType(DataType.MultilineText)]
        public String comments { get; set; }
        public String medicine { get; set; }
        public int actual { get; set; }
        public DateTime cancelDate { get; set; }
    }
