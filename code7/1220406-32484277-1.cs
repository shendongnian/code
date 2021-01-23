        public Glass()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        private bool rePaintState = false;
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.BackColor == Color.Transparent)
            {
                // we want to invalidate and force it to re-paint but just once
                if (rePaintState)
                {
                    rePaintState = false;
                }
                else
                {
                    rePaintState = true;
                    this.Invalidate();
                }
            }
        }
