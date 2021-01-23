     public class Person
     {
    public Person()
    {
    }
    
    [Key]
    public string SocialNumber { get; set; }
    public string Name { get; set; }
    
     public InfoOverTime InfoOverTime { get; set; }
     }
    
      public class Snapshot
     {
     public Snapshot()
     {
     }
    
    public int SnapshotId { get; set; }
    public DateTime Date { get; set; }
    }
    
     public class InfoOverTime
     {
    public InfoOverTime()
    {
    }
    
    [Key, Column(Order = 0), ForeignKey("Snapshot")]
    public int SnapshotId { get; set; }
    public virtual Snapshot Snapshot { get; set; }
    
    [Key, Column(Order = 1), ForeignKey("Person")]
    public string PersonId { get; set; }
    public virtual Person Person{ get; set; }
    
    public string Desc { get; set; }
    ...
    }
