    // create an HtmlDocument
    var htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(a);
    // get all elements with the attr data-glossaryid and prints its values
    foreach (var item in htmlDocument.DocumentNode.SelectNodes("//*[@data-glossaryid]"))
        Console.WriteLine(item.GetAttributeValue("data-glossaryid", ""));
