    using System.Drawing;
    namespace SO_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                using(Image newImage = GetImage("C:\\Users\\username\\Pictures\\image.png", "C:\\Users\\username\\Pictures\\watermark.jpg"))
                {
                    newImage.Save("C:\\Users\\username\\Pictures\\newImage.png");
                }
            }
            static Image GetImage(string sOriginalPath, string sLogoPath)
            {
                Image imgOriginal = Image.FromFile(sOriginalPath, true);
                using (Image imgLogo = Image.FromFile(sLogoPath, true)) //This is where it throws the exception
                {
                    using (Graphics gra = Graphics.FromImage(imgOriginal))
                    {
                        Bitmap bmLogo = new Bitmap(imgLogo);
                        int nWidth = bmLogo.Size.Width;
                        int nHeight = bmLogo.Size.Height;
                        int nLeft = (imgOriginal.Width/2) - (nWidth/2);
                        int nTop = (imgOriginal.Height/2) - (nHeight/2);
                        gra.DrawImage(bmLogo, nLeft, nTop, nWidth, nHeight);
                    }
                }
                return imgOriginal;
            }
        }
    }
