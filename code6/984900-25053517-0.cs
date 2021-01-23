    public class Domain
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Report> Reports { get; set; }
        public Domain()
        {
            Reports = new List<Report>();
        }
    }
