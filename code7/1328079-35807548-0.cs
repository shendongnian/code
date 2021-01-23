            string inFileName = @"C:\In.xml";
            string inXml = System.IO.File.ReadAllText(inFileName);
            var xmlReaderSource = XmlReader.Create(new StringReader(inXml));
            var mgr = new XmlNamespaceManager(xmlReaderSource.NameTable);
            mgr.AddNamespace("m", "http://www.mismo.org/residential/2009/schemas");
            XDocument sourceXmlDoc = XDocument.Load(xmlReaderSource);
            string outFileName = @"C:\Out.xml";
            string outXml = System.IO.File.ReadAllText(outFileName);
            XmlDocument targetXmlDoc = new XmlDocument();
            targetXmlDoc.LoadXml(outXml);
            IEnumerable<XElement> inStudentsElements = 
                sourceXmlDoc.Root.Elements("Classes").Descendants("Class")
                              .Descendants("Students").Descendants("Student");
            XmlNodeList outStudentsElements = targetXmlDoc.GetElementsByTagName("Students")[0].ChildNodes;
            var inStudentsList = inStudentsElements.Select(i => 
                new { SequenceNumber = i.Attributes().First().Value, 
                                  Id = i.Elements().First().Value, 
                                Name = i.Elements().Last().Value });
            var outStudentsList = new List<object>();
            for (int i = 0; i < outStudentsElements.Count; i++)
            {
                outStudentsList.Add(new { SequenceNumber = outStudentsElements[i].Attributes[0].Value, 
                                                      Id = outStudentsElements[i].ChildNodes[0].InnerText, 
                                                    Name = outStudentsElements[i].ChildNodes[1].InnerText });
            }
            if (inStudentsList.SequenceEqual(outStudentsList))
            {
                return;
            }
            else
            {
                // add elements
            }
