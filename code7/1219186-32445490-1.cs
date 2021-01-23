    using System;
    using System.Drawing;
    
    namespace ellipse_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                const int pic_size_x = 500;
                const int pic_size_y = 500;
    
                Bitmap pBitmap = new Bitmap(pic_size_x, pic_size_y);
                using (Graphics g = Graphics.FromImage(pBitmap))
                {
                    g.Clear(Color.White);
                    const int num_circles = 12;
                    for (int i = 0; i < num_circles; i++)
                    {
                        //Compute the X/Y center
                        int x = i * pic_size_x / num_circles;
                        int y = i * pic_size_y / num_circles;
    
                        int radius = Math.Abs((int) ((x - 250)/(float)250 * 40)) + 10;
    
                        //Draw a circle there
                        g.FillPie(new SolidBrush(Color.Red), x, y, radius, radius, 0, 360);
                    }
                }
                pBitmap.Save(@"C:\Users\<yournamehere>\Desktop\Test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }
        }
    }
