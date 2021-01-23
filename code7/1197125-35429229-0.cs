    protected void buttonCreatePdf_Click(object sender, EventArgs e)
    {
        // create an empty PDF document
        PdfDocument document = new PdfDocument();
    
        // add a page to document
        PdfPage page1 = document.AddPage(PdfPageSize.A4, new PdfDocumentMargins(5), PdfPageOrientation.Portrait);
    
        try
        {
            // set the document header and footer before adding any objects to document
            SetHeader(document);
            SetFooter(document);
    
            // layout the HTML from URL 1
            PdfHtml html1 = new PdfHtml(textBoxUrl1.Text);
            html1.WaitBeforeConvert = 2;
            PdfLayoutInfo html1LayoutInfo = page1.Layout(html1);
    
            // determine the PDF page where to add URL 2
            PdfPage page2 = null;
            System.Drawing.PointF location2 = System.Drawing.PointF.Empty;
            if (checkBoxNewPage.Checked)
            {
                // URL 2 is laid out on a new page with the selected orientation
                page2 = document.AddPage(PdfPageSize.A4, new PdfDocumentMargins(5), GetSelectedPageOrientation());
                location2 = System.Drawing.PointF.Empty;
            }
            else
            {
                // URL 2 is laid out immediately after URL 1 and html1LayoutInfo
                // gives the location where the URL 1 layout finished
                page2 = document.Pages[html1LayoutInfo.LastPageIndex];
                location2 = new System.Drawing.PointF(html1LayoutInfo.LastPageRectangle.X, html1LayoutInfo.LastPageRectangle.Bottom);
            }
    
            // layout the HTML from URL 2
            PdfHtml html2 = new PdfHtml(location2.X, location2.Y, textBoxUrl2.Text);
            html2.WaitBeforeConvert = 2;
            page2.Layout(html2);
    
            // write the PDF document to a memory buffer
            byte[] pdfBuffer = document.WriteToMemory();
    
            // inform the browser about the binary data format
            HttpContext.Current.Response.AddHeader("Content-Type", "application/pdf");
    
            // let the browser know how to open the PDF document and the file name
            HttpContext.Current.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=LayoutMultipleHtml.pdf; size={0}",
                        pdfBuffer.Length.ToString()));
    
            // write the PDF buffer to HTTP response
            HttpContext.Current.Response.BinaryWrite(pdfBuffer);
    
            // call End() method of HTTP response to stop ASP.NET page processing
            HttpContext.Current.Response.End();
        }
        finally
        {
            document.Close();
        }
    }
    
    private void SetFooter(PdfDocument document)
    {
        if (!checkBoxAddFooter.Checked)
            return;
    
        //create the document footer
        document.CreateFooterCanvas(50);
    
        // layout HTML in footer
        PdfHtml footerHtml = new PdfHtml(5, 5, @"<span style=""color:Navy; font-family:Times New Roman; font-style:italic"">
                        Quickly Create High Quality PDFs with </span><a href=""http://www.hiqpdf.com"">HiQPdf</a>", null);
        footerHtml.FitDestHeight = true;
        footerHtml.FontEmbedding = true;
        document.Footer.Layout(footerHtml);
    
    
        float footerHeight = document.Footer.Height;
        float footerWidth = document.Footer.Width;
    
        // add page numbering
        System.Drawing.Font pageNumberingFont = new System.Drawing.Font(new System.Drawing.FontFamily("Times New Roman"), 8, System.Drawing.GraphicsUnit.Point);
        PdfText pageNumberingText = new PdfText(5, footerHeight - 12, "Page {CrtPage} of {PageCount}", pageNumberingFont);
        pageNumberingText.HorizontalAlign = PdfTextHAlign.Center;
        pageNumberingText.EmbedSystemFont = true;
        pageNumberingText.ForeColor = System.Drawing.Color.DarkGreen;
        document.Footer.Layout(pageNumberingText);
    
        string footerImageFile = Server.MapPath("~") + @"\DemoFiles\Images\HiQPdfLogo.png";
        PdfImage logoFooterImage = new PdfImage(footerWidth - 40 - 5, 5, 40, System.Drawing.Image.FromFile(footerImageFile));
        document.Footer.Layout(logoFooterImage);
    
        // create a border for footer
        PdfRectangle borderRectangle = new PdfRectangle(1, 1, footerWidth - 2, footerHeight - 2);
        borderRectangle.LineStyle.LineWidth = 0.5f;
        borderRectangle.ForeColor = System.Drawing.Color.DarkGreen;
        document.Footer.Layout(borderRectangle);
    }
