            public Main() {
            InitializeComponent();
            KeyUp += new KeyEventHandler(KeyUpEvent);
            this.KeyPreview = true;
        }
        private void KeyUpEvent(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                //btnResolveS2I_Click(sender, e);
                btnResolveS2I.PerformClick(); //Instead of calling the method you perform a click on the button.
                e.SuppressKeyPress = true;
            }
        }
        private void btnResolveS2I_Click(object sender, EventArgs e) {
            //Perform code here
        }
