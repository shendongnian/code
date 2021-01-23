    var doc = XDocument.Load(Transation);
    var latestRow = doc.Descendants("row")
    				   .OrderByDescending(r => (DateTime)r.Attribute("transactionDateTime"))
    				   .FirstOrDefault();
    var latestPrice = (decimal)latestRow.Attribute("price");
    Console.WriteLine(latestPrice);
