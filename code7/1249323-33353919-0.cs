    public class XmlConcatenate
    {
        public static void ConcatenateAllFiles()
        {
            string folder = @"C:\Temp\";
            string output = folder + "_all.xml";
            Encoding readEncoding = System.Text.Encoding.Default; // WHY NOT Encoding.UTF8 !?
            var files = new DirectoryInfo(folder).GetFiles("*.xml").Where(f => f.Name != "_all.xml").Select(f => f.FullName).Select(n => (TextReader)new StreamReader(n, readEncoding));
            using (var textWriter = new StreamWriter(output, false))
            {
                Concatenate(files, textWriter);
            }
        }
        public static void Concatenate(IEnumerable<TextReader> inputs, TextWriter output)
        {
            var writerSettings = new XmlWriterSettings() { Encoding = Encoding.UTF8, ConformanceLevel = ConformanceLevel.Fragment };
            var whiteSpace = new StringBuilder();
            int indent = 0;
            using (var writer = XmlWriter.Create(output, writerSettings))
            {
                var writeDepth = 0;
                var first = true;
                foreach (var input in inputs)
                {
                    using (input)
                    using (var reader = XmlReader.Create(input))
                    {
                        bool alreadyRead = false;
                        while (!reader.EOF && (alreadyRead || reader.Read()))
                        {
                            alreadyRead = false;
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    {
                                        if (reader.Depth == 0 && reader.LocalName == "CYPHS" && reader.NamespaceURI == "http://www.datadictionary.nhs.uk/messages/CYPHS-v1-5")
                                        {
                                            if (writeDepth == 0)
                                            {
                                                writer.WriteWhitespace(whiteSpace.ToString());
                                                writer.WriteStartElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
                                                writer.WriteAttributes(reader, true);
                                                writeDepth++;
                                            }
                                        }
                                        else if (reader.Depth == 1 && reader.LocalName == "CYP000" && reader.NamespaceURI == "")
                                        {
                                            if (writeDepth == 1)
                                            {
                                                indent = whiteSpace.ToString().Replace("\n", "").Replace("\r", "").Length;
                                                writer.WriteWhitespace(whiteSpace.ToString());
                                                writer.WriteStartElement(reader.LocalName, reader.NamespaceURI);
                                                writeDepth++;
                                            }
                                        }
                                        else if (reader.Depth == 2)
                                        {
                                            if (reader.LocalName.StartsWith("C000") && reader.NamespaceURI == "")
                                            {
                                                if (first)
                                                {
                                                    first = false;
                                                    writer.WriteWhitespace(whiteSpace.ToString());
                                                    writer.WriteNode(reader, false);
                                                    alreadyRead = true;
                                                }
                                            }
                                            else
                                            {
                                                writer.WriteWhitespace(whiteSpace.ToString());
                                                writer.WriteNode(reader, false);
                                                alreadyRead = true;
                                            }
                                        }
                                        whiteSpace.Length = 0; // Clear accumulated whitespace.
                                    }
                                    break;
                                case XmlNodeType.Whitespace:
                                    {
                                        whiteSpace.Append(reader.Value);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                while (writeDepth-- > 0)
                {
                    if (indent > 0)
                        writer.WriteWhitespace("\n" + new string(' ', indent * writeDepth));
                    writer.WriteEndElement();
                }
            }
        }
    }
