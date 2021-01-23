    Public abstract class ExtendedData
    {
        public int Id {get;set;}
        public string FieldName {get;set;}
        public string FieldValue {get;set;}
    }
    public class ExtendedPersonData : ExtendedData
    {}
    public class ExtendedJobData : ExtendedData
    {}
    public class Person
    {
        ....
        public virtual ICollection<ExtendedPersonData> ExtendedData {get;set}
    }
    public class Job
    {
        ....
        public virtual ICollection<ExtendedJobData> ExtendedData {get;set;}
    }
    public class Context : DbContext
    {
        ....
        public DbSet<ExtendedData> ExtendedData {get;set;}
    } 
    
    modelBuilder.Entity<ExtendedData>()
        .Map<ExtendedPersonData>(m => m.Requires("TableName").HasValue("Person"))
        .Map<ExtendedJobData>(m => m.Requires("TableName").HasValue("Job"));
