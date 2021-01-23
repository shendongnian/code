    using (FileStream file1 = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    using (IacDocument doc1 = new IacDocument())
                    {
                        doc1.Open(file1, "");
                        doc1.AttributeByName("Title").Value = documentName;
                        doc1.SetAttributeForMultipleSelection("UnicodeFonts", true, false);
                        doc1.Copies = printEvent.Copies;
                        bool printed = doc1.Print(printerName, false);
                        PrintSystemJobInfo PrintSystemJobInfo = GetPrintJob(printerName, fileName);
                        if (printed)
                        {
                            Logger.Log(string.Format("[AMYUNI]  PDF' {0} ' printed using printer {1}", documentName, printerName));
                            return true;
                        }
                        return false;
                    }
