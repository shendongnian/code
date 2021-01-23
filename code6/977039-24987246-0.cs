    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    namespace pic
    {
    public class Class1
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;
        public void t(int LocalX, int LocalY, string PicLocal, byte transparency)
        {
            Bitmap bitmap;
            Form f = new Form();
            f.BackColor = Color.White;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Bounds = Screen.PrimaryScreen.Bounds;
            f.TopMost = true;
            bitmap = new Bitmap(PicLocal);
            f.Size = new Size(600, 600);
            f.StartPosition = FormStartPosition.Manual;
            f.SetDesktopLocation(LocalX, LocalY);
            Application.EnableVisualStyles();
            PictureBox PictureBox1 = new PictureBox();
            PictureBox1.Location = new System.Drawing.Point(70, 120);
            PictureBox1.Image = bitmap;
           PictureBox1.Size = new System.Drawing.Size(140, 140);
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            f.Controls.Add(PictureBox1);
            
            f.AllowTransparency = true;
            SetWindowLong(f.Handle, GWL_EXSTYLE,
            (IntPtr)(GetWindowLong(f.Handle, GWL_EXSTYLE) | WS_EX_LAYERED | WS_EX_TRANSPARENT));
            // set transparency to 50% (128)
            SetLayeredWindowAttributes(f.Handle, 0, transparency, LWA_ALPHA);
         
            Color BackColor = Color.White;
            f.TransparencyKey = BackColor;
            f.Opacity = transparency / 255f;
           
            Application.Run(f);
        }
    }
    }
