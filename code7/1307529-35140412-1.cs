    public partial class FrmPopup : Form {
        public FrmPopup() {
            InitializeComponent();
        }
        const uint WM_NCACTIVATE = 0x0086;
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_NCACTIVATE && m.WParam == IntPtr.Zero) {
                if(!ClientRectangle.Contains(PointToClient(Control.MousePosition)) && MouseButtons == MouseButtons.Left)
                    label1.Text = "Clicked outside of window";
            }
        }
    }
