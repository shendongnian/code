     protected void btnExport_Click(object sender, EventArgs e)
        {
            dtUIExport = GetData();
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dtUIExport.Columns.Count - 1);
           
            pdfTable.DefaultCell.BorderWidth = 2;
            int[] widths = new int[dtUIExport.Columns.Count - 1];
           //setting font
            BaseFont bf = BaseFont.CreateFont(Environment.GetEnvironmentVariable("windir") + @"\fonts\ARIALUNI.TTF", BaseFont.IDENTITY_H, true);
           
            //setting width
            for (int x = 0; x < domainGridview.Columns.Count -1; x++)
            {
              widths[x] = (int)domainGridview.Columns[x].HeaderText.Length + 100;              
            }
            pdfTable.SetWidths(widths);
            //setting headers
            for (int i = 0; i < dtUIExport.Columns.Count; i++)
            {
                if (i == 1)
                { continue; }
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                font.Color = new BaseColor(domainGridview.HeaderStyle.ForeColor);
                string cellText = Server.HtmlDecode(dtUIExport.Columns[i].ToString());               
                 iTextSharp.text.pdf.PdfPCell cell = new PdfPCell(new Phrase(12, cellText, font));
                 pdfTable.AddCell(cell);     
            }
            //copying the data to pdftable
            for (int i = 0; i < dtUIExport.Rows.Count; i++)
            {
                for (int j = 0; j < dtUIExport.Columns.Count; j++)
                {
                    if (j == 1)
                    { continue; }
                    
                        string cellText = Server.HtmlDecode(dtUIExport.Rows[i][j].ToString());
                        iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                        font.Color = new BaseColor(domainGridview.RowStyle.ForeColor);
                        iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new Phrase(12, cellText, font));
                        pdfTable.AddCell(cell);
                }
            }
           //creating the PDF DOC
            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(pdfTable);
            pdfDoc.Close();
                
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfTable);
            Response.End();
        }        
    }
