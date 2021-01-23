    using System;  
    using System.Drawing;  
    using Spire.Pdf;  
    using Spire.Pdf.Graphics;  
      
    namespace DrawImage  
    {  
        class Program  
        {  
            static void Main(string[] args)  
            {  
                //Create PDF and Add Page  
                PdfDocument doc = new PdfDocument();  
                PdfPageBase page = doc.Pages.Add();  
      
                //Draw Image  
                PdfImage image = PdfImage.FromFile(@"D:\Images\Spring's Coming.png");  
                float width = image.Width * 0.75f;  
                float height = image.Height * 0.75f;  
                float x = (page.Canvas.ClientSize.Width - width) / 2;  
      
                page.Canvas.DrawImage(image, x, 60, width, height);  
      
                //Save and Launch   
                doc.SaveToFile("InsertImage.pdf");  
                doc.Close();  
                System.Diagnostics.Process.Start("InsertImage.pdf");  
            }  
        }  
    }  
