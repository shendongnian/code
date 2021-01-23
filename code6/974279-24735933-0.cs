    foreach (var htmlElement in parsedHtmlElements)
                                    {
                                        if (htmlElement is PdfPTable)
                                        {
                                            SetDirection(htmlElement as PdfPTable);
                                        }
                                        pdfDoc.Add(htmlElement);
                                    }
    private static void SetDirection(PdfPTable tbl)
            {
                tbl.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                tbl.HorizontalAlignment = Element.ALIGN_LEFT;
                foreach (PdfPRow pr in tbl.Rows)
                {
                    foreach (PdfPCell pc in pr.GetCells())
                    {
                        if (pc != null)
                        {
                            pc.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                            pc.HorizontalAlignment = Element.ALIGN_LEFT;
                            if (pc.CompositeElements != null)
                            {
                                foreach (var element in pc.CompositeElements)
                                {
                                    if (element is PdfPTable)
                                    {
                                        SetDirection((PdfPTable)element);
                                    }                               
                                }
                            }
                        }
                    }
                }
            }
