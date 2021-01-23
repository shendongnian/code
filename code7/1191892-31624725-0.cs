    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(htmltablestring);
    foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table[@id='table2']")) { 
     streamWriter.WriteLine(table.OuterHtml);
    }
