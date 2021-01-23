    private static void DoWork(XmlReader reader, Action<string> onElementStart, Action<string> onElementEnd, Action<string, string> onAttribute)
    {
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    onElementStart(reader.Name);
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            onAttribute(reader.Name, reader.Value);
                        }
                        // Move the reader back to the element node.
                        reader.MoveToElement();
                    }
                    if (reader.IsEmptyElement)
                    {
                        // Do something special for empty elements?  
                    }
                    break;
                case XmlNodeType.Attribute:
                    onAttribute(reader.Name, reader.Value);
                    break;
                case XmlNodeType.EndElement:
                    onElementEnd(reader.Name);
                    break;
            }
        }
    }
    private static void doWork(string filename, Func<string, string> onElementStart, Func<string, string> onElementEnd, Func<string, string, string> onAttribute)
    {
        using (XmlReader reader = XmlReader.Create("file:///" + filename))
        {
            using (StreamWriter writer = new StreamWriter(@"c:\kajacx\other\troll_excel5\output.php"))
            {
                DoWork(reader, writer, onElementEnd, onElementEnd, onAttribute);
            }
        }
    }
    private static void DoWork(XmlReader reader, TextWriter writer, Func<string, string> onElementStart, Func<string, string> onElementEnd, Func<string, string, string> onAttribute)
    {
        DoWork(reader,
            (s) => writer.WriteLine(onElementStart(s)),
            (s) => writer.WriteLine(onElementEnd(s)),
            (s1, s2) => writer.WriteLine(onAttribute(s1, s2))
        );
    }
