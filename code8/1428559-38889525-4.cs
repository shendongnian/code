	XNamespace ns = "http://www.temenos.com/T24/OFSML/130";
	var columns = XDocument.Load("XML01.xml")
		   .Descendants(ns + "enquiryRecord")
		   .Descendants(ns + "column")
		   .ToList();
	Console.WriteLine(columns.ElementAtOrDefault(0)?.Value); // 0
	Console.WriteLine(columns.ElementAtOrDefault(2)?.Value); // data
    // Or
    Console.WriteLine((string)columns.ElementAtOrDefault(0)); // 0
    Console.WriteLine((string)columns.ElementAtOrDefault(2)); // data
