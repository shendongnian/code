    public class ControlToImageSnapshot
    {
        /// <summary>
        /// Conversion du controle en image PNG
        /// </summary>
        /// <param name="source">Contrôle à exporter</param>
        /// <param name="path">Destination de l'export</param>
        /// <param name="zoom">Taille désirée</param>
        public static void SnapShotPng(FrameworkElement source, string path, double zoom = 1.0)
        {
            try
            {
                var dir = Path.GetDirectoryName(path);
                if (dir != null && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)source.ActualWidth, (int)source.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                VisualBrush sourceBrush = new VisualBrush(source);
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();
                using (drawingContext)
                {
                    drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(source.ActualWidth, source.ActualHeight)));
                }
                renderTarget.Render(drawingVisual);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    encoder.Save(stream);
                }
                createPdfFromImage(path, @"C:\Temp\myfile.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void createPdfFromImage(string imageFile, string pdfFile)
        {
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 0, 0, 0, 0);
                PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                FileStream fs = new FileStream(imageFile, FileMode.Open);
                var image = iTextSharp.text.Image.GetInstance(fs);
                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                document.Add(image);
                document.Close();
                //open pdf file
                Process.Start("explorer.exe", pdfFile);
            }
        }
    }
