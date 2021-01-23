    var html = @"<p>
       <span>a1</span>
       <span>a2</span>
       <span>b1</span>
       <span>b2</span>
    </p>";
    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    var result = doc.DocumentNode.SelectNodes("//text()[normalize-space()]");
    foreach (var r in result)
    {
    	Console.WriteLine(r.InnerText);
    }
