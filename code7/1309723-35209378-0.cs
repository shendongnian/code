    try
    {
        string destinaton = @"C:\Temp\Junk\new_PDF_TIF_Document.pdf";
    
        Image MyImage = Image.FromFile(@"C:\Temp\Junk\Sample tif document 5 pages.tiff");
    
        PdfDocument doc = new PdfDocument();
    
        for (int PageIndex = 0; PageIndex < MyImage.GetFrameCount(FrameDimension.Page); PageIndex++)
        {
            MyImage.SelectActiveFrame(FrameDimension.Page, PageIndex);
    
            XImage img = XImage.FromGdiPlusImage(MyImage);
    
            var page = new PdfPage();
    
            if (img.Width > img.Height)
            {
                page.Orientation = PageOrientation.Landscape;
            }
            else
            {
                page.Orientation = PageOrientation.Portrait;
            }
            doc.Pages.Add(page);
    
            XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[PageIndex]);
    
            xgr.DrawImage(img, 0, 0);
        }
    
        doc.Save(destinaton);
        doc.Close();
        MyImage.Dispose();
    
        MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
