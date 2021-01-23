    using (WordprocessingDocument theDoc = WordprocessingDocument.Open(NewPath, true))
                    {
                        MainDocumentPart mainPart = theDoc.MainDocumentPart;
                        string content = null;
                        using (StreamReader reader = new StreamReader(theDoc.MainDocumentPart.HeaderParts.First().GetStream()))
                        {
                            content = reader.ReadToEnd();
                        }
                        Regex exheadDate = new Regex("plcDate");
                        content = exheadDate.Replace(content, "27/07/1992");
                        using (StreamWriter writer = new StreamWriter(theDoc.MainDocumentPart.HeaderParts.First().GetStream(FileMode.Create)))
                        {
                            writer.Write(content);
                        }
                        mainPart.Document.Save();
                    }
