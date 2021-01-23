    var nestedLevel = 0;
    var studentNestedLevel = 0;
    using (var reader = XmlTextReader.Create(@"Test.xml"))
    {
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    nestedLevel++;
                    if (studentNestedLevel > 0)
                        Console.Write("{0}: ", reader.Name);
                    if (reader.Name.ToLower() == "student")
                        studentNestedLevel = nestedLevel;
                    break;
                case XmlNodeType.Text:
                    if (studentNestedLevel > 0)
                        Console.WriteLine("{0}", reader.Value);
                    break;
                case XmlNodeType.XmlDeclaration:
                case XmlNodeType.ProcessingInstruction:
                    if (studentNestedLevel > 0)
                        Console.WriteLine("{0}: {1}", reader.Name, reader.Value);
                    break;
                case XmlNodeType.Comment:
                    break;
                case XmlNodeType.EndElement:
                    nestedLevel--;
                    if (reader.Name.ToLower() == "student")
                        studentNestedLevel = 0;
                    break;
            }
        }
    }
