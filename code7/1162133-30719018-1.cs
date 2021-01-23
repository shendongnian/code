    List<MyFileInfo> list = new List<MyFileInfo> ();
	foreach (string entry in Directory.GetFiles(@"c:\temp"))
	{
		list.Add (new MyFileInfo (entry));
	}
	XmlSerializer xsSubmit = new XmlSerializer(typeof(List<MyFileInfo>));
	StringWriter sww = new StringWriter();
	XmlWriter writer = XmlWriter.Create(sww);
	xsSubmit.Serialize(writer, list);
	Console.WriteLine (sww.ToString());
