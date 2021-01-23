     [XmlRoot("Items")]
    public class Items
    {
        [XmlElement("Owner", Order = 1)]
        public String Owner { get; set; }
          [XmlArray("Cars", Order = 2)]
          public Car[] carList { get; set; }
    }
  
    public class Car
    {
        [XmlElement("Car1")] // Order = 1 within "Car"
        public String Car1 { get; set; }
        [XmlElement("Car2")] // // Order = 2 within "Car"
        public String Car2 { get; set; }
    }
