        bool keyHold = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyHold) 
            {
                //Do stuff
            }
        }
        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                keyHold = true;
            }
        }
        private void key_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                keyHold = false;
            }
        }
