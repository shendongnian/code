        private void ResetFile(string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                try
                {
                    string uncheckValue = "w14:val=\"0\"";
                    string uncheckSymbol = "☐";
                    string checkValue = "w14:val=\"1\"";
                    string checkSymbol = "☒";
                    
                    foreach (SdtContentCheckBox ctrl in doc.MainDocumentPart.Document.Body.Descendants<SdtContentCheckBox>())
                    {
                        if (ctrl.Checked.Val == OnOffValues.One)
                        {
                            ctrl.InnerXml = ctrl.InnerXml.Replace(checkValue, uncheckValue);
                            if (ctrl.Parent.Parent.Descendants<SdtContentRun>().ToList().Count > 0)
                            {
                                SdtContentRun text = (SdtContentRun)ctrl.Parent.Parent.Descendants<SdtContentRun>().ToList()[0];
                                text.InnerXml = text.InnerXml.Replace(checkSymbol, uncheckSymbol);
                            }
                        }
                    }
                    doc.MainDocumentPart.Document.Save();
                }
                catch { }
            }
        }
