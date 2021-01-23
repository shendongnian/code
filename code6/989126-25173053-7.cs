    public T DeserializeShape<T>(string xml) where T : Shape
    {
    	var ser = new XmlSerializer(typeof(Shape));
    	using (var sr = new StringReader(xml))
    	{
    		return (T)ser.Deserialize(sr);
    	}
    }
    var circle = DeserializeShape<Circle>(xml);
    var square = DeserializeShape<Square>(xml); // etc....
