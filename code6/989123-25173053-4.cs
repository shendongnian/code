    var shape = new Circle { XPos = 1, YPos = 2, Radius = 3};
    var ser = new XmlSerializer(typeof(Shape));
    var xml = string.Empty;
    
    using(var sw = new StringWriter())
    {
    	ser.Serialize(sw, shape);
    	xml = sw.ToString();
    }
    
    using (var sr = new StringReader(xml))
    {
    	var obj = ser.Deserialize(sr);
    }
