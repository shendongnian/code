        public Glass()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Opaque, true);
            // Not convinced this next line helps
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
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
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.BackColor == Color.Transparent)
                this.Invalidate();
        }
