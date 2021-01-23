                var templateList = new List<string> 
                {
                   "ID",
                   "Name",
                   "Address",
                   "Phone",
                   "Email",
                   "Gender"     
                };
    
                using (XmlReader xmlReader = XmlReader.Create("MyXMLFile.xml"))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (StreamWriter csvWriter = new StreamWriter(memoryStream))
                        {
                            csvWriter.WriteLine("\"" + string.Join("\",\"", templateList) + "\"");
                            xmlReader.MoveToContent();
                            while (xmlReader.Read())
                            {
                                if (xmlReader.NodeType == XmlNodeType.Element &&
                                    (xmlReader.Name == "TRX" || xmlReader.Name == "TRXR"))
                                {
                                    csvWriter.Write('"');
    
                                    for (int i = 0; i < templateList.Count; i++)
                                    {
                                        csvWriter.Write(xmlReader.MoveToAttribute(templateList[i]) ? xmlReader.Value.Replace(",", string.Empty) : null);
    
                                        if (i < templateList.Count - 1)
                                            csvWriter.Write("\",\"");
                                    }
                                    csvWriter.WriteLine('"');
                                }
                            }
                            csvWriter.Flush();
                            memoryStream.Position = 0;
                            using (StreamReader streamReader = new StreamReader(memoryStream))
                            {
                                while ((streamReader.ReadLine()) != null)
                                {
                                    //Parse your csv line by line
                                }
                            }
                        }
                    }
                }
