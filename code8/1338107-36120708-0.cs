    public class Computer
    {
      public string DnsHostname { get; set; }
      [Key]
      public string Name { get; set; }
      public string OperatingSystem { get; set; }
      public string ServicePack { get; set; }
      public List<LocalGroup> LocalGroups { get; set; }
      public List<LocalUser> LocalUsers { get; set; }
    }
