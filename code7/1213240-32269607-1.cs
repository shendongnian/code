    public partial class intDB
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> debint { get; set; }
        public Nullable<System.DateTime> finint { get; set; }
        public Nullable<int> id_int { get; set; }
        public int id_tpint { get; set; }
        [ForeignKey("id_tpint")]
        public virtual tpintDB tp_intDB { get; set; }
    }
