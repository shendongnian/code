    using System.Drawing;
    
    namespace stuff
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Bitmap pImage = new Bitmap(@"C:\Users\...\Desktop\test.jpg");
                Bitmap pModified = new Bitmap(pImage.Width, pImage.Height);
    
                Color tintColor = Color.FromArgb(255, 0, 0);
    
                for (int x = 0; x < pImage.Width; x++)
                {
                    for (int y = 0; y < pImage.Height; y++)
                    {
                        //Calculate the new color
                        var oldColor = pImage.GetPixel(x, y);
                        byte red =(byte)(256.0f * (oldColor.R / 256.0f) * (tintColor.R / 256.0f));
                        byte blue = (byte)(256.0f * (oldColor.B / 256.0f) * (tintColor.B / 256.0f));
                        byte green = (byte)(256.0f * (oldColor.G / 256.0f) * (tintColor.G / 256.0f));
    
                        Color newColor = Color.FromArgb(red, blue, green);
                        pModified.SetPixel(x, y, newColor);
                    }
                }
                pModified.Save(@"C:\Users\...\Desktop\tint.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
    }
