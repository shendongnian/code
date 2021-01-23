		string xmlGood = @"<!DOCTYPE sgml [
	  <!ELEMENT sgml ANY>
	  <!ENTITY std       ""standard SGML"">
	  <!ENTITY signature "" &#x2014; &author;."">
	  <!ENTITY question  ""Why couldn&#x2019;t I publish my books directly in &std;?"">
	  <!ENTITY author    ""William Shakespeare"">
	]>
	<sgml>&question;&signature;</sgml>";
		var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
        
		using (var sr = new StringReader(xmlGood))
		using (var xmlReader = XmlReader.Create(sr, settings))
		{
			var doc = XDocument.Load(xmlReader);
			Console.WriteLine(doc);
		}				
