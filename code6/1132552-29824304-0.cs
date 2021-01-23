    //.Net Framework class from System.Drawing.Printing namespace
    PrintDocument pd = new PrintDocument();
    int pageForPrint = 0;
    
    pd.PrintPage += (s, e) =>
    {
        using (PdfBitmap bmp = new PdfBitmap((int)e.PageSettings.PrintableArea.Width, (int)e.PageSettings.PrintableArea.Height, true))
        {
            //Render to PdfBitmap using page's Render method with FPDF_PRINTING flag
            pdfView1.Document.Pages[pageForPrint].Render
                (bmp,
                0,
                0,
                (int)e.PageSettings.PrintableArea.Width,
                (int)e.PageBounds.Height,
                Patagames.Pdf.Enums.PageRotate.Normal, Patagames.Pdf.Enums.RenderFlags.FPDF_PRINTING);
    
            //Draw rendered image to printer's graphics surface
            e.Graphics.DrawImageUnscaled(bmp.Image,
                (int)e.PageSettings.PrintableArea.X,
                (int)e.PageSettings.PrintableArea.Y);
    
            //Print next page
            if(pageForPrint< pdfView1.Document.Pages.Count)
            {
                pageForPrint++;
                e.HasMorePages = true;
            }
        }
    };
    
    //start printing routine
    pd.Print();
