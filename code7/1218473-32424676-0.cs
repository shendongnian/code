    using System;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    
    namespace Samples
    {
        public class ImageFillBox : Control
        {
            public ImageFillBox()
            {
                SetStyle(ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, false);
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.Opaque | ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            }
            private Image image;
            public Image Image
            {
                get { return image; }
                set
                {
                    if (image == value) return;
                    image = value;
                    Invalidate();
                }
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (image == null)
                    e.Graphics.Clear(BackColor);
                else
                {
                    Size sourceSize = image.Size, targetSize = ClientSize;
                    float scale = Math.Max((float)targetSize.Width / sourceSize.Width, (float)targetSize.Height / sourceSize.Height);
                    var rect = new RectangleF();
                    rect.Width = scale * sourceSize.Width;
                    rect.Height = scale * sourceSize.Height;
                    rect.X = (targetSize.Width - rect.Width) / 2;
                    rect.Y = (targetSize.Height - rect.Height) / 2;
                    e.Graphics.DrawImage(image, rect);
                }
            }
        }
        static class Test
        {
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var testForm = new Form();
                testForm.Controls.Add(new ImageFillBox
                {
                    Dock = DockStyle.Fill,
                    Image = GetImage(@"http://www.celebrityrockstarguitars.com/rock/images/Metall_1.jpg")
                });
                Application.Run(testForm);
            }
            static Image GetImage(string path)
            {
                var uri = new Uri(path);
                if (uri.IsFile) return Image.FromFile(path);
                using (var client = new WebClient())
                    return Image.FromStream(new MemoryStream(client.DownloadData(uri)));
            }
        }
    }
