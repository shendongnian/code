     foreach (Paragraph paragraph in document.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
                {
                    bool ss = paragraph.InnerXml.Contains("commentRangeStart");
                    bool ee = paragraph.InnerXml.Contains("commentRangeEnd");
                    if (ss && ee)
                    {
                        foreach (Run run in paragraph.Elements<Run>())
                        {
                            foreach (Text text in run.Elements<Text>())
                            {
                                    text.Text = "your word " ;
                            }
                        }
                    }
                }
