    public void btnExecute_Click(object sender, EventArgs e)
    {   
        strFolder = tbFolder.Text;  
        strDestination = tbDestination.Text;
        strFileArray = Directory.GetFiles(strFolder, "*.tif");
  
        // Create the PDF with the proper parameters (change as you please)
        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 0, 0, 0, 0);
        // Ensure the path to the folder is located where all the merged TIFF files will be saved as a PDF  
        iTextSharp.text.pdf.PdfWriter writer = 
		   iTextSharp.text.pdf.PdfWriter.GetInstance(document, 
		   new System.IO.FileStream(strDestination + "/result2.pdf", System.IO.FileMode.Create));
        meregTiff(document, writer, strFileArray);
   
    }
    public void meregTiff(iTextSharp.text.Document document, iTextSharp.text.PdfWriter pdfWriter, string[] files)
    { 
    // Load each tiff files and convert it into a BITMAP and save it as a PDF
    // Recommendation: Use TRY/CATCH method to ensure any errors are handled properly...
    foreach (string image in files)
    {
        try
        {
            str = image.Substring(image.LastIndexOf("\\"));
            bm = new System.Drawing.Bitmap(Server.MapPath("~/TiffImages" + str)); //modify this to ensure the file exists (can be same as the page_load method)
            total = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
        }
        catch (Exception ce) //getting error here... Parameter is invalid.
        {
        }
        document.Open();
        iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
        for (int k = 0; k < total; ++k)
        {
            bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page, k);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bm, System.Drawing.Imaging.ImageFormat.Bmp);
            // scale the image to fit in the page 
            img.ScalePercent(72f / img.DpiX * 100);
            img.SetAbsolutePosition(0, 0);
            cb.AddImage(img);
            document.NewPage();
        }
       }
       document.Close();
     }
