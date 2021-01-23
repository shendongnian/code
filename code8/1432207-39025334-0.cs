        // create a PDF object
    Document pdf = new Document();
    // create a section and add it to pdf document
    Aspose.Pdf.Page MainSection = pdf.Pages.Add();
    //Add the radio form field to the paragraphs collection of the section
    // create an image object
    Aspose.Pdf.Image sample_image = new Aspose.Pdf.Image();
    // specify the image file path information
    sample_image.File = @"C:\pdftest\OutOfMemoryDemo\OutOfMemoryDemo\Sample.bmp";
    // specify the image width information equal to page width 
    sample_image.FixWidth = MainSection.PageInfo.Width - MainSection.PageInfo.Margin.Left - MainSection.PageInfo.Margin.Right;
    // specify the image Height information equal to page Height
    sample_image.FixWidth = MainSection.PageInfo.Height - MainSection.PageInfo.Margin.Top - MainSection.PageInfo.Margin.Bottom;
    
    // create bitmap image object to load image information
    System.Drawing.Bitmap myimage = new System.Drawing.Bitmap(@"C:\pdftest\OutOfMemoryDemo\OutOfMemoryDemo\Sample.bmp");
    // check if the width of the image file is greater than Page width or not
    if (myimage.Width > MainSection.PageInfo.Width)
        // if the Image width is greater than page width, then set the page orientation to Landscape
        MainSection.PageInfo.IsLandscape = true;
    else
        // if the Image width is less than page width, then set the page orientation to Portrait
        MainSection.PageInfo.IsLandscape = false;
    
    // add image to paragraphs collection of section
    MainSection.Paragraphs.Add(sample_image);
    MemoryStream stream = new MemoryStream();
    
    // save the resultant PDF
    pdf.Save(stream);
    
    StreamReader reader = new System.IO.StreamReader(Request.InputStream); 
    String Data = reader.ReadToEnd();
    this.Title = Data;
    Response.Clear();
    Response.ClearHeaders();
    Response.ClearContent();
    Response.Buffer = true;
    Response.Charset = "UTF-8";
    Response.AddHeader("Accept-Header", stream.Length.ToString());
    Response.AddHeader("Content-Length", stream.Length.ToString());
    Response.AddHeader("Expires", "0″");
    Response.AddHeader("Pragma", "cache");
    Response.AddHeader("Cache-Control", "private");
    Response.AddHeader("content-disposition", String.Format("inline;filename={0}", "article" + "docId"+ ".pdf"));
    Response.ContentType = "application/pdf";
    Response.AddHeader("Accept-Ranges", "bytes");
    Response.BinaryWrite(stream.ToArray());
    Response.Flush();
    Response.End();
