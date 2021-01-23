    namespace MouseClickDemo
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
            InitializeComponent();
            MouseClick += Form1_MouseClick;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                //Left mouse button hit
            }
            if(e.Button == MouseButtons.Right)
            {
                //Right mouse button hit
            }
        }
    }
