        public ctor()
        {
            // this does just work with OptimizedDoubleBuffer set to true
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do NOT paint the background here but in OnPaint() to prevent flickering!
            //base.OnPaintBackground(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // do the background and the base stuff first (if required)
            base.OnPaintBackground(e);
            base.OnPaint(e);
            // ... custom paint code goes here ...
        }
