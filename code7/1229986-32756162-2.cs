	//using System.Xml.Serialization;
	public T XmlDeserializeData<T>(string data)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(T));
		StringReader reader = new StringReader(data);
		T result = (T)serializer.Deserialize(reader);
		return result;
	}
	
    //using Newtonsoft.Json
	public string JsonSerializeData<T>(T data) 
	{
		var serializedData = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter());
		return serializedData; //notice the new Newtonsoft.Json.Converters.StringEnumConverter() to serialize enum as string
	}
