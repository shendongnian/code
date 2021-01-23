    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using iTextSharp;
    using iTextSharp.text;
    using iTextSharp.text.pdf; 
    namespace TxtToPdf
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Read the Data from Input File
                StreamReader rdr = new      StreamReader("Path/Test.txt");
               //Create a New instance on Document Class
                Document doc = new Document();
               //Create a New instance of PDFWriter Class for Output File
               PdfWriter.GetInstance(doc, new  FileStream("Path/Test.pdf", FileMode.Create));
               //Open the Document
                doc.Open();
               //Add the content of Text File to PDF File
               doc.Add(new Paragraph(rdr.ReadToEnd()));
               //Close the Document
               doc.Close();
               //Open the Converted PDF File
               System.Diagnostics.Process.Start("Path/Test.pdf");
            }
        }
    }
