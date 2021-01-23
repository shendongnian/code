    class EatMouseDown : NativeWindow
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WM.LBUTTONDOWN)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        new EatMouseDown().AssignHandle(mButton1.Handle);//Subclass a Handle
    }
