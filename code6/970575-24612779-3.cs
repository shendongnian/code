            string s = @"<root>
    <NameValueItem>
       <Text>Test</Text>
       <Code>Test</Code>
    </NameValueItem>
    <NameValueItem>
       <Text>Test2</Text>
       <Code>Test2</Code>
    </NameValueItem>
    </root>";
            var doc = XDocument.Load(new StringReader(s));
            var elms = doc.Descendants("NameValueItem");
            foreach (var element in elms)
            {
                element.Add(new XElement("Description", "TestDescription"));
            }
            var text = new StringWriter();
            doc.Save(text);
            Console.WriteLine(text);
