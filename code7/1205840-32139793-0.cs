     Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
    
                    foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                    {
                        Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        footerRange.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    
                        footerRange.Fields.Add(footerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldNumPages);
                        Microsoft.Office.Interop.Word.Paragraph p4 = footerRange.Paragraphs.Add();
                        p4.Range.Text = " of ";
                        footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
    
                        footerRange.Fields.Add(footerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                        Microsoft.Office.Interop.Word.Paragraph p1 = footerRange.Paragraphs.Add();
                        p1.Range.Text = "Page: ";
                        footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
    
                        Microsoft.Office.Interop.Word.Paragraph p3 = footerRange.Paragraphs.Add();
                        p3.Range.Text = " " + Environment.NewLine;
    
                        footerRange.Fields.Add(footerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldDate);
                        Microsoft.Office.Interop.Word.Paragraph p2 = footerRange.Paragraphs.Add();
                        p2.Range.Text = "Print date: ";
    
                        footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                    }
