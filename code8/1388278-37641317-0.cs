    protected virtual bool DoubleBuffered {
        get {
            return GetStyle(ControlStyles.OptimizedDoubleBuffer);
        }
        set {
            if (value != DoubleBuffered) {
                if (value) {
                    SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, value);
                }
                else {
                    SetStyle(ControlStyles.OptimizedDoubleBuffer, value);
                }
            }
        }
    }
