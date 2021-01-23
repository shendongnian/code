        public static String WatermarkFromFile(string sOriginalPath, string sLogoPath)
        {
            using (System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(sOriginalPath, true))
            {
                using (System.Drawing.Image imgLogo = System.Drawing.Image.FromFile(sLogoPath, true))
                {
                    using (Graphics gra = Graphics.FromImage(imgOriginal))
                    {
                        Bitmap bmLogo = new Bitmap(imgLogo);
                        int nWidth = bmLogo.Size.Width;
                        int nHeight = bmLogo.Size.Height;
                        int nLeft = (imgOriginal.Width / 2) - (nWidth / 2);
                        int nTop = (imgOriginal.Height / 2) - (nHeight / 2);
                        gra.DrawImage(bmLogo, nLeft, nTop, nWidth, nHeight);
                    }
                    string name = Path.GetFileName(sOriginalPath);
                    string id = Guid.NewGuid().ToString("N");
                    string sImage = ConfigurationManager.AppSettings["ApplicationPath"] + "\\watermark_" + id + "_" + name;
                    imgOriginal.Save(sImage, imgOriginal.RawFormat);
                    return sImage;
                }
            }
            return null;
        }
