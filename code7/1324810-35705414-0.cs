	static void Main(string[] args)
	{
		var doc = System.Xml.Linq.XDocument.Parse("<?xml version=\"1.0\" encoding=\"utf-8\"?> <Servers> <MYSERVER> <Host>xxx.xxx.xxx.xxx</Host> <User>MyUser</User> <Password>MyPassword</Password> <Port>25</Port> </MYSERVER> </Servers>");
		var servers = doc.Element("Servers").Elements().Select(x => x.Name);
		foreach(var s in servers)
		{
			Console.WriteLine(s);
		}
		Console.ReadLine();
	}
