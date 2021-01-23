    public class AModel
    {
        public List<AnotherModel> Items { get; set; }
    }
    public class AnotherModel
    {
        public int ApplicationId { get;set; }
        public DateTime ApplicationDate { get; set; }
        public string ApplicantName { get; set; }
        public bool Selected { get; set; }
    }
