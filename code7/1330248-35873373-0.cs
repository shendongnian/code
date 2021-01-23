            string[] inputFiles = { "XMLFile1.xml", "XMLFile2.xml" };
            using (XmlWriter xw = XmlWriter.Create("result.xml"))
            {
                xw.WriteStartDocument();
                xw.WriteStartElement("root");
                foreach (string inputFile in inputFiles)
                {
                    using (XmlReader xr = XmlReader.Create(inputFile))
                    {
                        xr.MoveToContent();
                        xw.WriteNode(xr, true);
                    }
                }
                xw.WriteEndElement();
                xw.WriteEndDocument();
