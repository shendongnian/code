    public class myPanel : Panel
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCLBUTTONDOWN:
                    this.InvokeOnClick(this, EventArgs.Empty);
                    break;
            }
            base.WndProc(ref m);
        }
    }
