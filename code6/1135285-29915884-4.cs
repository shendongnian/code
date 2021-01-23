    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                var fieldBooking = new FieldBooking();
                var fieldBookingMessageThread = new FieldBookingMessageThread();
                fieldBooking.FieldBookingMessageThread = new List<FieldBookingMessageThread>()
                {
                    fieldBookingMessageThread
                };
                context.FieldBookings.Add(fieldBooking);
                context.SaveChanges();
            }
            using (var context = new MyContext())
            {
                foreach (var item in context.FieldBookingMessageThreads.ToList())
                Console.WriteLine(
                    "Id: {0}, Created by: {1}, Created at: {2}",
                    item.FieldBookingMessageThreadID,
                    item.CreatedBy,
                    item.CreatedAt);
            }
            Console.ReadKey();
        }
    }
    public class MyContext : DbContext
    {
        private readonly string _user;
        public IDbSet<FieldBooking> FieldBookings { get; set; }
        public IDbSet<FieldBookingMessageThread> FieldBookingMessageThreads { get; set; }
        public MyContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
            _user = "Iain Galloway";
        }
        public override int SaveChanges()
        {
            var trackables = ChangeTracker.Entries<ITimestamps>().ToList();
            foreach (var item in trackables.Where(t => t.State == EntityState.Added))
            {
                item.Entity.CreatedAt = DateTime.Now;
                item.Entity.CreatedBy = _user;
                item.Entity.UpdatedAt = DateTime.Now;
                item.Entity.UpdatedBy = _user;
            }
            foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
            {
                item.Entity.UpdatedAt = DateTime.Now;
                item.Entity.UpdatedBy = _user;
            }
            return base.SaveChanges();
        }
    }
    public interface ITimestamps
    {
        DateTime CreatedAt { get; set; }
        
        string CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }
    public class FieldBooking : ITimestamps
    {
        [Key]
        public int FieldBookingID { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Updated by")]
        public string UpdatedBy { get; set; }
        public virtual List<FieldBookingMessageThread> FieldBookingMessageThread { get; set; }
    }
    public class FieldBookingMessageThread : ITimestamps
    {
        [Key]
        public int FieldBookingMessageThreadID { get; set; }
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated at")]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Updated by")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Field")]
        [Required]
        public virtual FieldBooking FieldBooking { get; set; }
    }
