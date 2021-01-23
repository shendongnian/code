    var parser = new Parser();
    var stylesheet = parser.Parse(css);
    var bodyBackgroundColor = stylesheet.StyleRules
      .FirstOrDefault(s => s.Selector.ToString() == "body")
      .Declarations
      .FirstOrDefault(d => d.Name == "background-color")
      .Term = new HtmlColor(255, 255, 255);
    Console.WriteLine(stylesheet.ToString(true, 0));
