    string html = @"<p>Rendered on a website,
                    this will all be on one line.</p>
                    <p>This would be on another line.</p>";
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(html);
    string text = HtmlEntity.DeEntitize(doc.DocumentNode.InnerText);
    Regex r = new Regex(@"\s+");
    var sentences = text.Replace(",\r\n", ", ").Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    var finalText = string.Join("\r\n", sentences.Select(s => r.Replace(s, " ").Trim()));
    Console.WriteLine(text + "\n");
    Console.WriteLine(finalText + "\n");
