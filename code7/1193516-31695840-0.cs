    public frmChequeFormat()
        {
            InitializeComponent();
            gbCheque.MouseMove += gbCheque_MouseMove;
        }
        bool mDown = false;
        private void gbCheque_MouseMove(object sender, MouseEventArgs e)
        {
            if (mDown)
            {
                label13.Location = e.Location;
            }
        }
        private void label13_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = true;
        }
        private void label13_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
        }
