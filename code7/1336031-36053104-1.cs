    using System.IO;
    using PdfSharp.Drawing;
    using PdfSharp.Pdf;  
    public sealed class PdfHelper
    {
        private PdfHelper()
        {
        }
        public static PdfHelper Instance { get; } = new PdfHelper();
        internal void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 600, bool deleteImage = false)
        {
            using (var document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                using (XImage img = XImage.FromFile(imageFileName))
                {
                    // Calculate new height to keep image ratio
                    var height = (int)(((double)width / (double)img.PixelWidth) * img.PixelHeight);
                    // Change PDF Page size to match image
                    page.Width = width;
                    page.Height = height;
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    gfx.DrawImage(img, 0, 0, width, height);                
                }
                document.Save(pdfFileName);
            }
        if (deleteImage)            
            File.Delete(imageFileName);
        }
    }
