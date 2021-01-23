        public Form1() {
            InitializeComponent();
            this.Opacity = 0.99;
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (!e.Cancel) {
                for (int op = 99; op >= 0; op -= 3) {
                    this.Opacity = op / 100f;
                    System.Threading.Thread.Sleep(15);
                }
            }
        }
    }
 
