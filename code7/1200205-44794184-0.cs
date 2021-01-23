    using (WordprocessingDocument doc = WordprocessingDocument.Open(docFilePath, true))
            {
                foreach (var paragraph in doc.MainDocumentPart.RootElement.Descendants<Paragraph>())
                {
                    foreach (var ele in paragraph.Descendants<DocumentFormat.OpenXml.Math.OfficeMath>())
                    {
                        string wordDocXml = ele.OuterXml;
                        XslCompiledTransform xslTransform = new XslCompiledTransform();
                        xslTransform.Load(officeMathMLSchemaFilePath);
                        var result = "";
                        using (TextReader tr = new StringReader(wordDocXml))
                        {
                            // Load the xml of your main document part.
                            using (XmlReader reader = XmlReader.Create(tr))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    XmlWriterSettings settings = xslTransform.OutputSettings.Clone();
                                    // Configure xml writer to omit xml declaration.
                                    settings.ConformanceLevel = ConformanceLevel.Fragment;
                                    settings.OmitXmlDeclaration = true;
                                    XmlWriter xw = XmlWriter.Create(ms, settings);
                                    // Transform our OfficeMathML to MathML.
                                    xslTransform.Transform(reader, xw);
                                    ms.Seek(0, SeekOrigin.Begin);
                                    using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                                    {
                                        result = MathML2Latex(sr.ReadToEnd());
                                        officeMLFormulas.Add(result);
                                    }
                                }
                            }
                        }
                        
                        Run run = new Run();
                        run.Append(new Text(result));
                        ele.InsertBeforeSelf(run);
                    }
                }
            }
