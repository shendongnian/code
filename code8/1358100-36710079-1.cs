     protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap bmpScreenshot = Screenshot();
            Bitmap bm;
            byte[] ss = ImageToByte(bmpScreenshot);
            using (var ms = new MemoryStream(ss))
            {
                bm = new Bitmap(ms);
                bm.Save("D:\\Test\\testimage.jpeg", ImageFormat.Jpeg);
            }
        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private Bitmap Screenshot()
        {
            Bitmap bmpScreenshot =
                    new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (var g = Graphics.FromImage(bmpScreenshot))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                return bmpScreenshot;
            }
        }
