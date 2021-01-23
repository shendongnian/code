    public class Worker 
    {
        public int ID { get; set; }
        public int OfficeID { get; set; }
        public virtual Office Office { get; set; }
        public string FullName { get; set; }
        // [NotMapped]
        // public string OfficeColor { get; set; }
    }
    public class Office 
    {
        private ICollection<Worker> workers;
        public Office 
        {
           this.workers = new HashSet<Worker>();
        } 
   
        public int ID { get; set; }
        public string Color { get; set; }
        public virtual ICollection<Worker> Workers
        {
            get { return this.workers; }
            set { this.workers = value; }
        }
    }
    // and get all workers from Db
    public class Program
    {
         public static void Main()
         {
           IEnumerable<WorkerViewModel> workers = DbContext.Workers.All().Select(w => 
              new WorkerViewModel()
              {
                   Id = w.Id,
                   OfficeId = w.Office.Id,
                   FullName = w.FullName,
                   OfficeColor = w.Office.Color
              })
              .ToList();
         }
    }
