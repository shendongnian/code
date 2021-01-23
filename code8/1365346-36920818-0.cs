    public partial class Form1 : Form
    {
        private bool _k1 = false;
        private bool _k2 = false;
        private bool _d1 = false;
        private bool _d2 = false;
        private int _u1 = 0;
        private int _u2 = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _k1 = true;
                    _d1= true;
                    break;
                case Keys.Down:
                    _k1 = true;
                    _d1 = false;
                    break;
                case Keys.W:
                    _k2 = true;
                    _d2 = true;
                    break;
                case Keys.S:
                    _k2 = true;
                    _d2 = false;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_k1)
                label1.Text =( _u1 = _u1 + (_d1 ? 1 : -1)).ToString();
            if (_k2)
                label2.Text = (_u2 = _u2 + (_d2 ? 1 : -1)).ToString();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    _k1 = false;
                    _d1 = true;
                    break;
                case Keys.Down:
                    _k1 = false;
                    _d1 = false;
                    break;
                case Keys.W:
                    _k2 = false;
                    _d2 = true;
                    break;
                case Keys.S:
                    _k2 = false;
                    _d2 = false;
                    break;
            }
        }
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            _k1 = false;
            _k2 = false;
        }
    }
