            public static string CreateAndSave(IEnumerable<string> orderPages, string filePath)
            {
                if (orderPages == null || !orderPages.Any())
                {
                    return string.Empty;
                }
                string result;
                var writerSettings = new XmlWriterSettings
                {
                    Indent = true,
                    Encoding = Encoding.GetEncoding("ISO-8859-1"),
                    CheckCharacters = false,
                    ConformanceLevel = ConformanceLevel.Document
                };
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    try
                    {
                        XmlWriter xmlWriter = XmlWriter.Create(fs, writerSettings);
                        xmlWriter.WriteStartElement("PRINT_JOB");
                        foreach (var page in orderPages)
                        {
                            xmlWriter.WriteElementString("PAGE", page);
                        }
                        xmlWriter.WriteFullEndElement();
                        xmlWriter.Close();  // Flush from xmlWriter to fs
                        fs.Seek(0, SeekOrigin.Begin); // Go back to read from the begining
                        var reader = new StreamReader(fs, writerSettings.Encoding);
                        result = reader.ReadToEnd();
                        // reader.Close();  // This would just flush/close fs early(which would be OK)
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return result;
            }
