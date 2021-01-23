    internal class myTextBox : TextBox
    {
        const int WM_MOUSEWHEEL = 0x020A;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEWHEEL)
                m.HWnd = this.Parent.Handle; // Change the Handle of the message
            base.WndProc(ref m);
        }
    }
