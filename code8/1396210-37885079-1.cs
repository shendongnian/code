	public abstract class Root
	{
		
		public string Sender { get; set; }
		
		public string IP { get; set; }
		[Persist("", ChildName = "NodeWhatever")]
		public List<Node> Nodes { get; set; }
	}
	[PersistInclude(typeof(SomeData),typeof(SomeOtherData))]
	public class Node
	{
		[Persist("")]
		public List<BaseElement> Elements { get; set; }
	}
    XmlArchive serial = new XmlArchive(R.GetType());
	Archive.ClassKwd = "type";
	string utf8 = ""; ;
	using (var mm = new MemoryStream())
	{
		serial.Write(mm,R,"MyRequestName");
		mm.Position = 0;
		
		using (var reader = new StreamReader(mm))
		{
			utf8 = reader.ReadToEnd();
		}	
	}
	Console.WriteLine(utf8);	
