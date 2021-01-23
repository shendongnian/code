	XNamespace ns = XNamespace.Get("http://test.net/schema/session/1.0");
	
	IEnumerable<XElement> failures =
		doc
			.Descendants(ns + "download")
			.Elements(ns + "result")
			.Elements(ns + "message")
			.Where(e => e.Parent.Attributes("success").Any(a => !(bool)a));
