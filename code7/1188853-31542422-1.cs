    public partial class Members
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public Nullable<bool> Eligible { get; set; }
        public Nullable<System.DateTime> InsertLogtime { get; set; }
    }
