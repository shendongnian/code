        public static byte[] AddImageToPdf(byte[] pdf, byte[] img, double x, double y)
        {
            using (var msPdf = new MemoryStream(pdf))
            {
                using (var msImg = new MemoryStream(img))
                {
                    var image = Image.FromStream(msImg);
                    var document = PdfReader.Open(msPdf);
                    var page = document.Pages[0];
                    var gfx = XGraphics.FromPdfPage(page);
                    var ximg = XImage.FromGdiPlusImage(image);
                    ximg.Interpolate = false;
                    gfx.DrawImage(
                        ximg,
                        XUnit.FromCentimeter(x),
                        XUnit.FromCentimeter(y),
                        ximg.PixelWidth * 72 / ximg.HorizontalResolution,
                        ximg.PixelHeight * 72 / ximg.HorizontalResolution);
                    using (var msFinal = new MemoryStream())
                    {
                        document.Save(msFinal);
                        return msFinal.ToArray();
                    }
                }
            }
        }
