        private void ResetFile(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                try
                {
                    string uncheckValue = "☐";
                    string checkValue = "☒";
                    
                    foreach (SdtContentCheckBox ctrl in doc.MainDocumentPart.Document.Body.Descendants<SdtContentCheckBox>())
                    {
                        if (ctrl.Checked.Val == OnOffValues.One)
                        {
                            ctrl.Checked.Val = OnOffValues.Zero;
                            if (ctrl.Parent.Parent.Descendants<SdtContentRun>().ToList().Count > 0)
                            {
                                SdtContentRun text = (SdtContentRun)ctrl.Parent.Parent.Descendants<SdtContentRun>().ToList()[0];
                                text.InnerXml = text.InnerXml.Replace(checkValue, uncheckValue);
                            }
                        }
                    }
                    doc.MainDocumentPart.Document.Save();
                }
                catch { }
            }
        }
