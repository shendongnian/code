        XElement e = XElement.Parse(@"<root>
                                        <child ID=""123"">A</child>
                                        <child ID=""234"">B</child>
                                      </root>");
    
        Console.Out.WriteLine(e.XPathSelectElement("(//child)[1]").Value);
