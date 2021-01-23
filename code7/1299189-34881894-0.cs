    string xml = @"<ABCProperties> <Action> Yes | No | None </Action><Content>
    <Header> Header Text </Header><Body1> Body Paragraph 1 </Body1>
    <BodyN> Body Paragraph N</BodyN></Content><IsTrue> true | false </IsTrue>
    <Duration> Long | Short </Duration></ABCProperties>";
    XDocument doc = XDocument.Parse(xml);
    XElement content = doc.Root.Element("Content");
    foreach (XElement el in content.Elements())
    {
        string localName = el.Name.LocalName;
        if (localName == "Header")
        {
            Console.WriteLine(localName + ": " + el.Value.Trim());
        }
        else if (localName.StartsWith("Body"))
        {
            Console.WriteLine(localName + ": " + el.Value.Trim());
        }
    }
    Console.ReadKey();
