    var reader = new StringReader(@"<Employees>
        <Person>
            <ID>1000</ID>
            <Name>Nima</Name>
            <LName>Agha</LName>
        </Person>
        <Person>
            <ID>1002</ID>
            <Name>Ligha</Name>
            <LName>Ligha</LName>
        </Person>
        <Person>
            <ID>1003</ID>
            <Name>Jigha</Name>
            <LName>Jigha</LName>
        </Person>
    </Employees>");
    var xdoc = XDocument.Load(reader);
    xdoc.Element("Employees").Elements("Person").First().AddAfterSelf(new XElement("Person", 
        new XElement("ID", 1001),
        new XElement("Name", "Aba"),
        new XElement("LName", "Aba")));
    
    var sb = new StringBuilder();
    var writer = new StringWriter(sb);
    xdoc.Save(writer);
    Console.WriteLine(sb);
