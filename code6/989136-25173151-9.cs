    public static T Deserialize<T>(string xmlToDeserialize) where T : Shape
    {
    	XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shape));
    
    	using (StringReader reader = new StringReader(xmlToDeserialize)) {
    		 return (T)xmlSerializer.Deserialize(reader);
    	}
    }
