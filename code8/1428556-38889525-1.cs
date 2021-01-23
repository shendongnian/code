	var columns = XDocument.Load("data.xml").Root
                           .Descendants("enquiryRecord") //Add this only if you have columns also not under enquiryRecord
						   .Descendants("column")
						   .ToList();
	Console.WriteLine(columns.ElementAtOrDefault(0)?.Value);
	Console.WriteLine(columns.ElementAtOrDefault(2)?.Value);
    //before C#6.0
    var column1 = columns.ElementAtOrDefault(0);
    Console.WriteLine(column1 == null ? string.Empty : colum1.Value);
    var column3 = columns.ElementAtOrDefault(2);
    Console.WriteLine(column3 == null ? string.Empty : colum3.Value);
