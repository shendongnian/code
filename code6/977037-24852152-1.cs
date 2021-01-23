    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
    static class Program
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string PicLocal = @"C:\Projects\Screenshot_1.bmp";
            Form f = new Form() {  FormBorderStyle = FormBorderStyle.None, StartPosition = FormStartPosition.CenterScreen};
            f.BackgroundImage = new Bitmap(PicLocal);
            f.Size = new Size(f.BackgroundImage.Size.Width, f.BackgroundImage.Size.Height);
            f.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, 200, 200, 2000, 2000));
            f.Click += (s, e) => { System.Windows.Forms.MessageBox.Show("Clicked"); };
            Application.Run(f);
        }
    }
