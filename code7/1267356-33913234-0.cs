    var xml = @"
    <xml>
        <Books>
            <Title>Book 1</Title>
            <Author>A</Author>
        </Books>
        <Books>
            <Title>Book 2</Title>
            <Author>B</Author>
        </Books>
    </xml>";
    
    var originalElements = XDocument.Parse(xml).Root.Elements("Books").Descendants();
    var newDoc = new XDocument(new XElement("Books", originalElements));
