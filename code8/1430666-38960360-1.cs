            PdfPTable table;
            string inputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "input.pdf");
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.pdf");
    
    List<ImageTextSharpModel> images
    PdfPTable table = new PdfPTable(images.Count);
                        table.WidthPercentage = 100;
                        table.HorizontalAlignment = Element.ALIGN_RIGHT;
                       
                        for (var i = 0; i < images.Count; i++)
                        {
                            var image = images[i];
                            try
                            {
                                PdfPCell cell = new PdfPCell();
                                cell.BorderWidth = 0;
                                cell.FixedHeight = image.Height;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;                                  
                                Paragraph p = new Paragraph();
                                float offset = 0;
                                var img = iTextSharp.text.Image.GetInstance(image.AbsolutePath);
                                img.ScaleToFit(image.Width, image.Height);
                                //Manually setting the location 
                                if (image.Alignment == iTextSharp.text.Image.RIGHT_ALIGN)
                                {
                                    offset = i == 0
                                        ? (((doc.PageSize.Width/images.Count) - doc.LeftMargin) - img.ScaledWidth)
                                        : (((doc.PageSize.Width/images.Count) - doc.LeftMargin) - img.ScaledWidth) - cell.Width;
                                }
                                else if (image.Alignment == iTextSharp.text.Image.ALIGN_CENTER)
                                {
                                    if (images.Count == 1)
                                    {
                                        offset = ((doc.PageSize.Width - img.ScaledWidth)/2) - doc.LeftMargin;
                                    }
                                    else
                                    {
                                        offset = (((doc.PageSize.Width/images.Count) - img.ScaledWidth)/2);
                                    }
                                }     
                                
                                p.Add(new Chunk(img, offset, 0));
                                cell.AddElement(p);
                                table.AddCell(cell);
                            }
                            catch (Exception ex)
                            {
                                //Ignore
                            } 
                        }
    ;
                   
    			//add table to stamper
    iTextSharp.text.pdf.PdfReader pdfReader = new     iTextSharp.text.pdf.PdfReader(inputFile);
    using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        using (PdfStamper stamper = new PdfStamper(pdfReader, fs))
            {
                    int PageCount = pdfReader.NumberOfPages;
                    for (int x = 1; x <= PageCount; x++)
                    {
                        
                        PdfContentByte canvas = stamper.GetOverContent(x);
                        PdfTemplate tableTemplate = canvas.CreateTemplate(1500, 1300);
                        table.WriteSelectedRows(0, -1, 0, 1300, tableTemplate);
                                                
                    }
                    stamper.Close();
                }
            }
