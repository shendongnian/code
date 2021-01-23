        public class Folder : AbstractItem
    {
        [XmlElement("File", Type = typeof(File))]
        [XmlElement("Folder", Type = typeof(Folder))]
        public List<AbstractItem> Items { get; set; }
	}
    public class File : AbstractItem
	{
		// Empty
	}
	
	public abstract class AbstractItem {
        [XmlElement("name")]
        public string Name { get; set; }	
	}
