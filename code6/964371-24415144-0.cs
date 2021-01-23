    class ExtendedRTB : System.Windows.Forms.RichTextBox
    {
        // this piece of code was taken from pgfearo's answer
        // ------------------------------------------
        // http://stackoverflow.com/questions/5041348/richtextbox-and-userpaint
        private const int WM_PAINT = 15;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                // raise the paint event
                using (Graphics graphic = base.CreateGraphics())
                    OnPaint(new PaintEventArgs(graphic,
                     base.ClientRectangle));
            }
        }
        // --------------------------------------------------------
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("hello", this.Font, Brushes.Black, 0, 0);
        }
    }
