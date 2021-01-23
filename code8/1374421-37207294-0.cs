    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    HtmlNode firstTable = doc.DocumentNode.SelectSingleNode("//table");
    var orderedCellTexts = firstTable.Descendants("tr")
        .Select(row => row.SelectNodes("th|td").Take(2).ToArray())
        .Where(cellArr => cellArr.Length == 2)
        .Select(cellArr => new { Cell1 = cellArr[0].InnerText, Cell2 = cellArr[1].InnerText })
        .OrderBy(x => x.Cell1)
        .ToList();
