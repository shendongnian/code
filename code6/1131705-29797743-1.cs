    namespace WatermarkDemo
    {
        public class Class1
        {
           void myMethod()
           {
               string watermarkedFile = "Watermarked.pdf";
               // Creating watermark on a separate layer
               // Creating iTextSharp.text.pdf.PdfReader object to read the Existing PDF Document
               PdfReader reader1 = new PdfReader(originalFile);
               using (FileStream fs = new FileStream(watermarkedFile, FileMode.Create, FileAccess.Write, FileShare.None))
        ...
