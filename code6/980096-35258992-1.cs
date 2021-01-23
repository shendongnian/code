    public class GraphicsPanel : Panel
    {
        private const int WS_EX_COMPOSITED = 0x02000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }
        public GraphicsPanel()
        {
            this.DoubleBuffered = true;
        }
    }
