    var expression = "href=\"(.*)\"";
    var list = document.GetElementsByTagName("a")
                       .Cast<HtmlElement>()
                       .Where(x => Regex.IsMatch(x.OuterHtml, expression))
                       .Select(x => Regex.Match(x.OuterHtml, expression).Groups[1].Value)
                       .ToList();
