    [Table(name="address")]
    public class Address{
      [Datamember(Name="images")]
      public IEnumerable<Image> Images{get;set;}
    }
