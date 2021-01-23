    public partial class Form1 : Form
    {
        private bool _stop;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void buttonStart_Click(object sender, EventArgs e)
        {
            _stop = false;
            FrqSent();
        }
    
        private void buttonStop_Click(object sender, EventArgs e)
        {
            _stop = true;
        }
    
        private void FrqSent()
        {
            int i = 1;
            while (i <= 5000000 && !_stop)
            {
                i = i + 1;
                Application.DoEvents();
            }
        }
    
    }
