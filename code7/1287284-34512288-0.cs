    	public class Monster
    	{
    		[XmlAttribute("name")]
    		public string Name;
    		public int Mana;
    		public int Health;
    		[XmlArray("Drops")]
    		[XmlArrayItem("Drop")]
    		public List<Drop> Drops;
    	}
    
    	public class Drop
    	{
    		[XmlText]
    		public string DropInfo;
    	}
    }
