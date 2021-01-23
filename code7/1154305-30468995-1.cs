    [Designer(typeof(CustomDesigner))]
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            const int WM_LBUTTONDOWN = 0x0201;
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN: // Yes, it's defined correctly.
                    MessageBox.Show("Left Button Down");
                    break;
            }
        }
    }
