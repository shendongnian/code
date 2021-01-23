    [XmlRoot(ElementName="Root")]
    public class Root
    {
      public IEnumerable<CruiseProduct> CruiseProducts{ get; set; }
    }
    XmlSerializer serializer = new XmlSerializer(typeof(Root));
    using (StreamReader file = new System.IO.StreamReader(Server.MapPath("~/XmlFiles/CruiseData/cruiseprodutstwo.xml")))
    {
      var data = (Root)serializer.Deserialize(file);
      var observablecruiseProducts = new ObservableCollection<CruiseProduct>(data.CruiseProducts);
    }
