    public partial class Form1 : Form
    {
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        enum HitTest
        {
            Caption = 2,
            Transparent = -1,
            Nowhere = 0,
            Client = 1,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
            Border = 18
        }
        private const int WM_SIZING = 0x214;
        private const int WM_NCHITTEST = 0x84;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    var result = (HitTest)m.Result.ToInt32();
                    if (result == HitTest.Top || result == HitTest.Bottom)
                        m.Result = new IntPtr((int)HitTest.Caption);
                    if (result == HitTest.TopLeft || result == HitTest.BottomLeft)
                        m.Result = new IntPtr((int)HitTest.Left);
                    if (result == HitTest.TopRight || result == HitTest.BottomRight)
                        m.Result = new IntPtr((int)HitTest.Right);
                    break;
                case WM_SIZING:
                    // Retrieve the "proposed" size of the Form in "rc":
                    RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                    // ... do something with "rc" ...
                    // this is your code (slightly modified):
                    if (itemPanel.Controls.Count > 0)
                    {
                        var lastElement = itemPanel.Controls[itemPanel.Controls.Count - 1];
                        if (lastElement.Bottom + lastElement.Margin.Bottom != itemPanel.Height)
                        {
                            int Height = 38 + lastElement.Bottom + lastElement.Margin.Bottom;
                            rc.Bottom = rc.Top + Height; // <--- use "Height" to update the "rc" struct
                        }
                    }
                    
                    // Put the updated "rc" back into message structure:
                    Marshal.StructureToPtr(rc, m.LParam, true);
                    break;
            }
        }
    }
