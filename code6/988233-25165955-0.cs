            byte[] content;
            using (MemoryStream output = new MemoryStream())
            {
                PdfReader pdf_rdr = new PdfReader(strpath);
                PdfStamper stamper = new PdfStamper(pdf_rdr, output);
                PdfContentByte pcb = stamper.GetOverContent(pdf_rdr.NumberOfPages);
                PdfPTable ftbl = clsPDF.CreateTable(1, false, cell_padding_bottom: 0f);
                Paragraph fp = new Paragraph(new Phrase("Line 1 of footer\r\nLine 2 of footer\r\nhere's more of my footer text:\r\nthis project was SOOOO much fun\r\nand stuff", fb8));
                //get the height of the footer
                float footer_height = clsPDF.GetTotalHeightOfParagraph(fp);
                Console.WriteLine("Footer height {0}", footer_height.ToString());
                //get the total amount of "writeable" space per page
                //(taking top and bottom margins into consideration)
                float avail = doc.PageSize.Height - (doc.TopMargin + doc.BottomMargin);
                //declare a variable to assist in calculating
                //the total amount of "writeable" room remaining
                //on the last page;
                //start with with the current height of the master table
                //(will do math below to calculate just what it's using
                // on the last page)
                float mas_tbl_last_page_height = mas_tbl.TotalHeight;
                mas_tbl_last_page_height = mas_tbl_last_page_height % avail;
                avail = avail - mas_tbl_last_page_height;
                Console.WriteLine(clsPDF.GetTotalHeightOfParagraph(fp).ToString());
                //float ft_top = avail - mas_tbl_last_page_height - clsPDF.GetTotalHeightOfParagraph(fp) - doc.BottomMargin;
                float ft_top = doc.BottomMargin + clsPDF.GetTotalHeightOfParagraph(fp);
                ftbl.AddCell(fp);
                if (avail < clsPDF.GetTotalHeightOfParagraph(fp))
                {
                    stamper.InsertPage(pdf_rdr.NumberOfPages + 1, pdf_rdr.GetPageSize(1));
                    pcb = stamper.GetOverContent(pdf_rdr.NumberOfPages);
                    ft_top = doc.PageSize.Height - doc.TopMargin;
                }
                ftbl.WriteSelectedRows(0, -1, doc.LeftMargin, ft_top, pcb);
                // Set the flattening flag to true, as the editing is done
                stamper.FormFlattening = true;
                // close the pdf stamper
                stamper.Close();
                //close the PDF reader
                pdf_rdr.Close();
                content = output.ToArray();
            }
            //write the content to a PDF file
            using (FileStream fs = File.Create(strpath))
            {
                fs.Write(content, 0, (int)content.Length);
                fs.Flush();
            }
