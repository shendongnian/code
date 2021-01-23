    public class myPanel : Panel
    {
        public myPanel()
        {
            this.Click += myPanel_Click;
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCLBUTTONDOWN:
                    Clicked();
                    break;
            }
            base.WndProc(ref m);
        }
        void myPanel_Click(object sender, EventArgs e)
        {
            Clicked();
        }
        private void Clicked()
        {
            this.BackColor = Color.Red;
        }
    }
