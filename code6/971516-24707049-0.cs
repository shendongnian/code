     public class AeroForm : Form
     {
        int _w = 100, _h = 100;
        bool aero = false;
    
        [StructLayout(LayoutKind.Sequential)]
        struct MARGINS { public int Left, Right, Top, Bottom;  }
    
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea
                                  (IntPtr hwnd, ref MARGINS margins);
    
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();
    
        public AeroForm()
        {
                aero = IsCompositionEnabled();
            }
    
            public AeroForm(int width, int height)
                : this()
            {
                _w = width;
                _h = height;
                Size = new Size(width, height);
            }
    
            protected override void WndProc(ref Message m)
            {
                const int WM_NCCALCSIZE = 0x0083;
                switch (m.Msg)
                {
                    case WM_NCCALCSIZE:
                        if (aero)
                            return;
                        break;
                }
                base.WndProc(ref m);
            }
    
            //this is for checking the OS's functionality.
            //Windows XP does not have dwmapi.dll
            //also, This corrupts the designer... 
            //so i used the Release/Debug configuration
            bool IsCompositionEnabled()
            {
        #if !DEBUG
                return File.Exists(Environment.SystemDirectory + "\\dwmapi.dll")
                     && DwmIsCompositionEnabled();
        #else
                return false;
        #endif
            }
    
            //this one is used for a shadow when aero is not available
            protected override CreateParams CreateParams
            {
                get
                {
                    const int CS_DROPSHADOW = 0x00020000;
                    const int WS_MINIMIZEBOX = 0x20000;
                    const int CS_DBLCLKS = 0x8;
                    CreateParams cp = base.CreateParams;
                    if (!aero)
                        cp.ClassStyle |= CS_DROPSHADOW;
                    cp.Style |= WS_MINIMIZEBOX;
                    cp.ClassStyle |= CS_DBLCLKS;
                    return cp;
                }
            }
    
            //this is for aero shadow and border configurations
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                if (aero)
                {
                    FormBorderStyle = FormBorderStyle.FixedSingle;
                    ControlBox = false;
                    MinimizeBox = false;
                    MaximizeBox = false;
                    Size = new Size(_w, _h);
                    MARGINS _glassMargins = new MARGINS()
                    {
                        Top = 5,
                        Left = 5,
                        Bottom = 5,
                        Right = 5
                    };
                    DwmExtendFrameIntoClientArea(this.Handle, ref _glassMargins);
                }
                else
                    FormBorderStyle = FormBorderStyle.None;
            }
    
            //When you minimize and restore, the size will change.
            //this override is for preventing this unwanted resize.
            protected override void OnPaint(PaintEventArgs e)
            {
                if (aero)
                    Size = new Size(_w, _h);
                base.OnPaint(e);
            }
        }
