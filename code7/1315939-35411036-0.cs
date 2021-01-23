        public Form1() {
            InitializeComponent();
            Application.Idle += CheckFlpFocus;
            this.Disposed += delegate { Application.Idle -= CheckFlpFocus; };
        }
        private bool FlpHasFocus;
        private void CheckFlpFocus(object sender, EventArgs e) {
            bool hasFocus = false;
            for (var ctl = this.ActiveControl; ctl != null; ctl = ctl.Parent) {
                if (ctl == flowLayoutPanel1) hasFocus = true;
            }
           if (hasFocus != FlpHasFocus) {
                FlpHasFocus = hasFocus;
                flowLayoutPanel1.BackColor = hasFocus ? Color.Black : Color.White;
            } 
        }
