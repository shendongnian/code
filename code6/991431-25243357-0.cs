    public partial class Form1 : Form
    {
        bool isTabPressed = false;
        public Form1()
        {
            InitializeComponent();
            button1.KeyDown += button1_KeyDown;
            button1.KeyUp += button1_KeyUp;
        }
        void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) 
            {
                isTabPressed = true;
            }
        }
        void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) 
            {
                isTabPressed = false;
            }
        }
    }
