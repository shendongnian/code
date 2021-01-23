    public partial class formB : Form
    {
        public formA owner;
        public formB()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (owner != null)
                owner.BackgroundImage = button1.BackgroundImage;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (owner != null)
                owner.BackgroundImage = button3.BackgroundImage;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (owner != null)
                owner.BackgroundImage = button3.BackgroundImage;
        }
    }
