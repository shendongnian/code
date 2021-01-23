    using System.Drawing;
    
    namespace stuff
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Bitmap pImage1 = new Bitmap(@"C:\Users\...\Desktop\PNGtest.png");
                Bitmap pImage2 = new Bitmap(@"C:\Users\...\Desktop\logo.png");
    
                using(Graphics g = Graphics.FromImage(pImage1))
                {
                    g.DrawImage(pImage2, new Point(0, 0));
                    g.Save();
                }
                pImage1.Save(@"C:\Users\...\Desktop\merged.png", System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
