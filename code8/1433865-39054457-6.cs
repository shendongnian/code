    using System.Drawing;
    using System.Windows.Forms;
    public class MyComboBox : ComboBox
    {
        int flash = 0;
        private const int WM_PAINT = 0xF;
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth;
        public Color HotBorderColor { get; set; }
        private bool DrawBorder { get; set; }
        Timer timer;
        public MyComboBox()
        {
            this.HotBorderColor = Color.Red;
            timer = new Timer() { Interval = 100 };
            timer.Tick += new System.EventHandler(timer_Tick);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && this.DrawBorder)
                using (var g = Graphics.FromHwnd(this.Handle))
                using (var p = new Pen(this.HotBorderColor))
                    g.DrawRectangle(p, 0, 0, this.Width - 1, this.Height - 1);
        }
        public void FlashHotBorder()
        {
            flash = 0;
            timer.Start();
        }
        void timer_Tick(object sender, System.EventArgs e)
        {
            if (flash < 10)
            {
                flash++;
                this.DrawBorder = !this.DrawBorder;
                this.Invalidate();
            }
            else
            {
                timer.Stop();
                flash = 0;
                DrawBorder = false;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) { timer.Dispose(); }
            base.Dispose(disposing);
        }
    }
