    public class Master
    {
        public long MasterId { get; set; }
        public object MasterValue { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
    public class Detail
    {
        public long DetailId { get; set; }
        public long MasterId { get; set; }
        public object DetailValue { get; set; }
        public Master Master { get; set; }
    }
    public class YourContext : DbContext
    {
        public DbSet<Master> Master { get; set; }
        public DbSet<Detail> Detail { get; set; }
    }
    public class Test
    {
        public void TestMethod(Master inputMaster) //it comes in non-attached state
        {
            using (var context = new YourContext())
            {
                //there are 2 ways to attach entity.
                //First one:
                context.Master.Attach(inputMaster);
                //SecondOne:
                //var master = context.Master.Find(inputMaster.MasterId);
                //master variable will be attached
                //Modifying entity:
                inputMaster.MasterValue = new object();
                context.SaveChanges();
                //Deleting all relations:
                inputMaster.Details.Clear();
                context.SaveChanges();
                //Adding new Detail:
                var newDetail = new Detail();
                inputMaster.Details.Add(newDetail);
                context.SaveChanges();
                //deleting particular Detail:
                inputMaster.Details.Remove(newDetail);
                context.SaveChanges();
            }
        }
    }
