    public class DataItemGroup
    {
      [Key]
      public int ID { get; set; }
      public string Name { get; set; }       
      public virtual ICollection<DataItem> DataItems { get; set; }
    }
