    using System;
    using System.Xml;
    using System.Xml.Serialization;
    
    public class Player
    {
    	public string Name {get; set;}
    }
    
    
    public class Program
    {
    	public static void Main()
    	{
    		var str = "<Player><Name>Bobby</Name></Player>";
    		var doc = new XmlDocument();
    		var XML_serializer = new XmlSerializer(typeof(Player));
    		doc.LoadXml(str);
    		Player player_after_load;
    		using (var nodeReader = new XmlNodeReader(doc))
    		{
    			player_after_load = (Player)XML_serializer.Deserialize(nodeReader);
    		}
    		Console.WriteLine(player_after_load.Name);
    			
    	}
    }
