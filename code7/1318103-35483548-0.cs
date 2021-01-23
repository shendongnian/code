    var o = new XmlSerializerNamespaces();
    o.Add("", "");
    var ser = new XmlSerializer(typeof(List<Order>), "");
    using (var sw = new StringWriter())
    {
         ser.Serialize(sw, new List<Order> { 
                    new Order { sequence = "1", MyProperty = 1 }, 
                    new Order { sequence = "2", MyProperty = 2 } },
                    o);
         var t = sw.ToString();
    }
    AND 
    [XmlAttribute(AttributeName = "sequence", DataType = "string")]
    public string sequence { get; set; }
