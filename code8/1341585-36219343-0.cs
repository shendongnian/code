    using iTextSharp.text;
    using iTextSharp.text.pdf;
     
    Document doc1 = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);;
    FileStream fs1;
    PdfWriter wri1;
    fs1 = new FileStream("C:\\1.pdf", FileMode.Create, FileAccess.ReadWrite);
    //Create Document class object and set its size to letter and give space left, right, Top, Bottom Margin
    wri1 = PdfWriter.GetInstance(doc1, fs1);
    doc1.Open();
    PdfPTable t = new PdfPTable(4);
    t.AddCell(new PdfPCell(new Phrase("RepGroup Logo")) { Rowspan = 9 });
    t.AddCell(new PdfPCell(new Phrase("CID")));
    t.AddCell(new PdfPCell(new Phrase("CID-Val")));
    t.AddCell(new PdfPCell(new Phrase("Ven Logo")) { Rowspan = 9 });
    t.AddCell(new PdfPCell(new Phrase("CPO")));
    t.AddCell(new PdfPCell(new Phrase("CPO-Val")));
    t.AddCell(new PdfPCell(new Phrase("Order Status")));
    t.AddCell(new PdfPCell(new Phrase("Confirmed")));
    t.AddCell(new PdfPCell(new Phrase("Order Date")));
    t.AddCell(new PdfPCell(new Phrase("10/02/2013")));
    t.AddCell(new PdfPCell(new Phrase("Ship Date")));
    t.AddCell(new PdfPCell(new Phrase("12/01/2013")));
    t.AddCell(new PdfPCell(new Phrase("Back Orders")));
    t.AddCell(new PdfPCell(new Phrase("Accepted")));
    t.AddCell(new PdfPCell(new Phrase("Ship Via")));
    t.AddCell(new PdfPCell(new Phrase("Best Way")));
    t.AddCell(new PdfPCell(new Phrase("Terms")));
    t.AddCell(new PdfPCell(new Phrase("CC")));
    doc1.Add(t);
    doc1.Close();
    Process myProcess = new Process();
    myProcess.StartInfo.FileName = "acroRd32.exe"; //not the full application path
    myProcess.StartInfo.Arguments = "C:\\1.pdf";   // "/A \"page=2=OpenActions\" C:\\example.pdf";
    myProcess.Start();
