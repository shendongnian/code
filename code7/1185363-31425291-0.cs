    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte Status { get; set; }
        public Nullable<System.Guid> Salt { get; set; }
    }
