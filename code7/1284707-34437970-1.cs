        using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    
    namespace BmpMadness
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (Image bmp = Image.FromFile("target.bmp"))
                using (Bitmap newBmp = new Bitmap(bmp, new Size(48, 48)))
                using (Bitmap newFormatBmp = newBmp.Clone(new Rectangle(0, 0, newBmp.Width, newBmp.Height), PixelFormat.Format24bppRgb))
                {
    
                    // DestroyIcon(pntr);   - dont need it. 
                    using (System.IO.Stream st = new System.IO.FileStream("final.ico", FileMode.Create))
                    {
                        IntPtr pntr = newFormatBmp.GetHicon();
                        Icon nwico = Icon.FromHandle(pntr);
                        System.IO.BinaryWriter wr = new System.IO.BinaryWriter(st);
                        nwico.Save(st);
                    }
    
                    //create the final icon by writing in the temp one and then saving to hdd overwritting to it
                    using (var Iconex = new IconEx("final.ico"))
                    {
                        Iconex.Items.RemoveAt(0);
                        IconDeviceImage IcondeviceImage = new IconDeviceImage(new Size(48, 48), ColorDepth.Depth32Bit);
                        IcondeviceImage.IconImage = new Bitmap(bmp);
                        Iconex.Items.Add(IcondeviceImage);
                        Iconex.Save("deviceImage.ico");
                    }
                }
            }
        }
    }
