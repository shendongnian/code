			var rootObject = new RootObject
			{
				OtherSerializedObjects = new object[]{}
			};
	
			var serializer = new XmlSerializer(typeof(RootObject));
			var stringWriter = new StringWriter();
			var ns = RootObject.GetAdditionalNamespaces();
	
			var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
			using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
			{
				serializer.Serialize(xmlWriter, rootObject, ns);
			}
			
			Console.WriteLine(stringWriter.ToString()); 
