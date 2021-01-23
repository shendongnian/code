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
        private void Key_up(object sender, KeyEventArgs e)
        {
            Key key = (Key) sender;
            if (key == Key.A) //Specify your key here !
            {
                keyHold = false;
            }
        }
        private void Key_down(object sender, KeyEventArgs e)
        {
            Key key = (Key)sender;
            if (key == Key.A) //Specify your key here !
            {
                keyHold = true;
            }
        }
