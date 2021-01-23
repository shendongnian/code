    using System.IO;
    using System.Text;
    using org.pdfbox.pdmodel;
    using org.pdfbox.util;
     
    namespace PDFReader
    {
        class Program
        {
     
            public static void pdf2txt(FileInfo pdffile, FileInfo txtfile)
            {
     
                PDDocument doc = PDDocument.load(pdffile.FullName);
     
                PDFTextStripper pdfStripper = new PDFTextStripper();
     
                string text = pdfStripper.getText(doc);
     
                StreamWriter swPdfChange = new StreamWriter(txtfile.FullName, false, Encoding.GetEncoding("gb2312"));
     
                swPdfChange.Write(text);
     
                swPdfChange.Close();
     
            }
     
            static void Main(string[] args)
            {
                pdf2txt(new FileInfo(@"C:/Users/yourpdf.pdf"), new FileInfo(@"C:/Users/yourcontent.txt"));
            }
        }
    }
