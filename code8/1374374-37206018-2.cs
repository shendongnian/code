    struct MinMaxInfo
    {
        public Point ptReserved;
        public Point ptMaxSize;
        public Point ptMaxPosition;
        public Point ptMinTrackSize;
        public Point ptMaxTrackSize;
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0x0024) //WM_GETMINMAXINFO
        {
            MinMaxInfo minMaxInfo = (MinMaxInfo)m.GetLParam(typeof(MinMaxInfo));
            minMaxInfo.ptMaxSize.X = MaximumSize.Width; //Set size manually
            minMaxInfo.ptMaxSize.Y = MaximumSize.Height;
            minMaxInfo.ptMaxPosition.X = Location.X; //Stay at current position
            minMaxInfo.ptMaxPosition.Y = Location.Y;
            Marshal.StructureToPtr(minMaxInfo, m.LParam, true);
        }
        base.WndProc(ref m);
    }
