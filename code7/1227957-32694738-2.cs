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
        public void ChangeMasterValue(Master master, object newValue)
        {
            using (var context = new YourContext())
            {
                context.Master.Attach(master);
                master.MasterValue = newValue;
                context.SaveChanges();
            }
        }
        public void DeleteAllDetailsFromMaster(Master master)
        {
            using (var context = new YourContext())
            {
                context.Master.Attach(master);
                master.Details.Clear();
                context.SaveChanges();
            }
        }
        public void AddDetailToMaster(Master master, Detail newDetail)
        {
            using (var context = new YourContext())
            {
                context.Master.Attach(master);
                master.Details.Add(newDetail);
                context.SaveChanges();
            }
        }
        public void DeleteDetailFromMaster(Master master, Detail detailToDelete)
        {
            using (var context = new YourContext())
            {
                context.Master.Attach(master);
                master.Details.Remove(detailToDelete);
                context.SaveChanges();
            }
        }
        public void UpdateMaster(Master master)
        {
            using (var context = new YourContext())
            {
                context.Master.Attach(master);
                context.Entry(master).State=EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
