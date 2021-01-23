	void Main()
	{
	
	var xml = @"
	<Container>
	<Items>
			<Item SomeField=""Value""/>
			<Item SomeField=""Value"" OtherField=""OtherValue""/>
	</Items>
	</Container>
	";
	
	var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
	
		var ser = new XmlSerializer(typeof(Container));
		
		var container = (Container) ser.Deserialize(stream);
	
		container.Dump();
	}
