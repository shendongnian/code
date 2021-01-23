    public partial class Station
    {
      ...
      [IgnoreDataMemeber]
      public virtual ICollection<Record> Records { get; set; }
    }
