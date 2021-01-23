    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    var instance = new MyClass {
            Property1 = "One",
            Property2 = "Twp",
            Property3 = "Three"
	};
	var ser = new DataContractJsonSerializer(instance.GetType());
	
    using (MemoryStream ms = new MemoryStream())
	{
		ser.WriteObject(ms, instance);
		string jsonData = Encoding.Default.GetString(ms.ToArray());
	}
    [DataContract]
    public class MyClass
    {
    	[DataMember]
    	public string Property1 { get; set; }
    	[DataMember]
    	internal string Property2 { get; set; }
    	[DataMember]
    	public string Property3 { get; set; }
    }
