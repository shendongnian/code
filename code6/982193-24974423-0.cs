    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Diagnostics;
    
    public void WriteDocument()
    {
       //Declare a itextSharp document
        Document document = new Document(PageSize.A4);
    
        //Create our file stream and bind the writer to the document and the stream
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"C:\Test.Pdf", FileMode.Create));
    
        //Open the document for writing
        document.Open();
    
       //Add a new page
        document.NewPage();
    
        //Reference a Unicode font to be sure that the symbols are present.
        BaseFont bfArialUniCode = BaseFont.CreateFont(@"C:\ARIALUNI.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //Create a font from the base font
        Font font = new Font(bfArialUniCode, 12);
    
        //Use a table so that we can set the text direction
        PdfPTable table = new PdfPTable(1);
        //Ensure that wrapping is on, otherwise Right to Left text will not display
        table.DefaultCell.NoWrap = false;
    
        //Create a regex expression to detect hebrew or arabic code points
        const string regex_match_arabic_hebrew = @"[\u0600-\u06FF,\u0590-\u05FF]+";
        if (Regex.IsMatch("مسندم", regex_match_arabic_hebrew, RegexOptions.IgnoreCase))
        {
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        }
    
        //Create a cell and add text to it
        PdfPCell text = new PdfPCell(new Phrase("مسندم", font));
        //Ensure that wrapping is on, otherwise Right to Left text will not display
        text.NoWrap = false;
    
        //Add the cell to the table
        table.AddCell(text);
    
        //Add the table to the document
        document.Add(table);
    
        //Close the document
        document.Close();
    
        //Launch the document if you have a file association set for PDF's
        Process AcrobatReader = new Process();
        AcrobatReader.StartInfo.FileName = @"C:\Test.Pdf";
        AcrobatReader.Start();
    
    }
