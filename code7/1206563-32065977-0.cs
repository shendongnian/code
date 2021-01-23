    using System;
    using iTextSharp.text.pdf;
    using System.IO;
    using iTextSharp.text;
    using System.Diagnostics;
    protected void btnGeneratePDFFile_Click(object sender, EventArgs e)
    {
    //Create document
    Document doc = new  Document();
    //Create PDF Table
    PdfPTable tableLayout = new PdfPTable(4);
 
    //Create a PDF file in specific path
    PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("Sample-PDF-File.pdf"), FileMode.Create));
 
    //Open the PDF document
    doc.Open();
 
    //Add Content to PDF
    doc.Add(Add_Content_To_PDF(tableLayout));
 
    // Closing the document
    doc.Close();
 
    btnOpenPDFFile.Enabled = true;
    btnGeneratePDFFile.Enabled = false;
      }
    private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
    {
    float[] headers = { 20, 20, 30, 30 };  //Header Widths
    tableLayout.SetWidths(headers);        //Set the pdf headers
    tableLayout.WidthPercentage = 80;       //Set the PDF File witdh percentage
 
       //Add Title to the PDF file at the top
       tableLayout.AddCell(new PdfPCell(new Phrase("Creating PDF file using    iTextsharp", new Font(Font.HELVETICA, 13, 1, new iTextSharp.text.Color(153, 51, 0)))) { Colspan = 4, Border = 0, PaddingBottom = 20, HorizontalAlignment = Element.ALIGN_CENTER });         
 
       //Add header
    AddCellToHeader(tableLayout, "Cricketer Name");
    AddCellToHeader(tableLayout, "Height");
    AddCellToHeader(tableLayout, "Born On");
    AddCellToHeader(tableLayout, "Parents");           
 
    //Add body
    AddCellToBody(tableLayout, "Sachin Tendulkar");
    AddCellToBody(tableLayout, "1.65 m");
    AddCellToBody(tableLayout, "April 24, 1973");
    AddCellToBody(tableLayout, "Ramesh Tendulkar, Rajni Tendulkar");
 
    AddCellToBody(tableLayout, "Mahendra Singh Dhoni");
    AddCellToBody(tableLayout, "1.75 m");
    AddCellToBody(tableLayout, "July 7, 1981");
    AddCellToBody(tableLayout, "Devki Devi, Pan Singh");
 
    AddCellToBody(tableLayout, "Virender Sehwag");
    AddCellToBody(tableLayout, "1.70 m");
    AddCellToBody(tableLayout, "October 20, 1978");
    AddCellToBody(tableLayout, "Aryavir Sehwag, Vedant Sehwag");
 
    AddCellToBody(tableLayout, "Virat Kohli");
    AddCellToBody(tableLayout, "1.75 m");
    AddCellToBody(tableLayout, "November 5, 1988");
    AddCellToBody(tableLayout, "Saroj Kohli, Prem Kohli");
 
    return tableLayout;
    }
 
    // Method to add single cell to the header
    private static void AddCellToHeader(PdfPTable tableLayout,string cellText)
    {          
    tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1, iTextSharp.text.Color.WHITE))) {HorizontalAlignment = Element.ALIGN_CENTER, Padding=5, BackgroundColor = new iTextSharp.text.Color(0, 51, 102) });
    }
 
    // Method to add single cell to the body
    private static void AddCellToBody(PdfPTable tableLayout, string cellText)
    {           
    tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.HELVETICA, 8, 1, iTextSharp.text.Color.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER,Padding = 5, BackgroundColor = iTextSharp.text.Color.WHITE });
    }
