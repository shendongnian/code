    [Serializable]
    public class Info {
    	[XmlArray("Datas")]
    	[XmlArrayItem("Data",  Type = typeof(Data))]
    	public List<Data> Datas { get; set; }
    }
