    public class StreetType
    {
      public int ID { get; set; }
      public string Name { get; set; }
      [IgnoreDataMember]
      public virtual ICollection<Street> Streets { get; set; }
    }
