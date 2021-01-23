    public class ClickTransparentPanel : Panel
    {
        protected override void WndProc(ref Message m)
        {
            // To make panel "transparent" 
            // to mouse clicks i.e. Mouse clicks pass through this window
            switch (m.Msg)
            {
                case (int) Win32Constants.WM_NCHITTEST:
                    m.Result = new IntPtr((int) Win32Constants.HTTRANSPARENT);
                    return;
            }
            base.WndProc(ref m);
        }
    }
