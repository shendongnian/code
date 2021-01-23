               for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            if (c == 5)
                            {
                               Object oMissing = oDoc.Tables[1].Cell(r + 2, 6).Range; //the position where you want to put the images
                               Image sparePicture = ByteArrayToImage((byte[])DGV.Rows[r].Cells[c].Value);
                                Clipboard.SetImage(sparePicture);
                                Word.Paragraph oPara2 = oDoc.Content.Paragraphs.Add(ref oMissing);
                                oPara2.Range.Paste();
                                oPara2.Range.InsertParagraphAfter();
                            }
                        }
                    }
