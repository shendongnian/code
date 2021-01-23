    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Media;
    using PixelFormat = System.Drawing.Imaging.PixelFormat;
    using Rectangle = System.Windows.Shapes.Rectangle;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public double x;
            public double y;
            public double width;
            public double height;
            public bool isMouseDown;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            public void SaveScreen(double x, double y, double width, double height)
            {
                var ix = Convert.ToInt32(x);
                var iy = Convert.ToInt32(y);
                var iw = Convert.ToInt32(width);
                var ih = Convert.ToInt32(height);
                try
                {
                    var slika = new Bitmap(iw, ih, PixelFormat.Format32bppArgb);
                    var g = Graphics.FromImage(slika);
                    g.CopyFromScreen(ix, iy, 0, 0, new Size(iw, ih), CopyPixelOperation.SourceCopy);
    
                    var dlg = new SaveFileDialog
                    {
                        DefaultExt = "png",
                        Filter = "Png Files|*.png"
                    };
                    var res = dlg.ShowDialog();
                    if (res == DialogResult.OK) slika.Save(dlg.FileName, ImageFormat.Png);
                }
                catch
                {
                }
    
            }
    
            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                isMouseDown = true;
                x = Cursor.Position.X;
                y = Cursor.Position.Y;
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
    
            }
    
            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {
                width = Cursor.Position.X - x;
                height = Cursor.Position.Y - y;
                Hide();
                Size = new Size(0, 0);
                Application.DoEvents();
                SaveScreen(x, y, width, height);
                x = y = 0;
                isMouseDown = false;
                Close();
            }
    
        }
    }
