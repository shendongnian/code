                        object oMissing = System.Reflection.Missing.Value;
                        object oEndOfDoc = "\\endofdoc";
                        Word._Application oWord;
                        Word._Document oDoc;
                        oWord = new Word.Application();
                        oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                            ref oMissing, ref oMissing);
                        Word.Paragraph oPara1;
                        oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                        oPara1.Range.Paste();
                        oDoc.SaveAs(docOutput);
