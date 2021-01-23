	var columns = XDocument.Load("XML01.xml").Root
                           .Descendants("enquiryRecord") //Add this only if you have columns also not under enquiryRecord
						   .Descendants("column")
						   .ToList();
	Console.WriteLine(columns.ElementAtOrDefault(0)?.Value); // 0
	Console.WriteLine(columns.ElementAtOrDefault(2)?.Value); // data
    // Or
    Console.WriteLine((string)columns.ElementAtOrDefault(0)); // 0
    Console.WriteLine((string)columns.ElementAtOrDefault(2)); // data
