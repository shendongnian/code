    namespace TrackerEntityFrameworks.Structure
    {
      public class MyContext: DbContext
      {
        public DbSet<TripRecord> TripRecords { get; set; }
        public DbSet<TollRecord> TollRecords { get; set; }
        public DbSet<MyData> MyDatas { get; set; }
      }
    }
    namespace TrackerEntityFrameworks.Models
    {
      public class MyData
      {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    
        // navigation properties: check how to implement relationships in EF Code First
        public ICollection<TripRecord> TripRecords { get; set; }
        public ICollection<TollRecord> TollRecords { get; set; }
      }
    }
    using(var myContext = new TrackerEntityFrameworks.Structure.MyContext())
    {
      var result = myContext.MyDatas
                      .Where(m => m.ID == 1)
                      .FirstOrDefault();
      string json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
    }
