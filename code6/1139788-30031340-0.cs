    [XmlRoot(Namespace = "http:/MyProject.ServiceContracts/2006/11", IsNullable = false)]
    public class UserInfo
    {
      [XmlElement]
      public string UserName { get; set; }
      [XmlElement]
      public string Age { get; set; }
    }
