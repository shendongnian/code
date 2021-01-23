     public Form1()
        {
            InitializeComponent();
            this.Deactivate += Form1_Deactivate;
            this.Activated += Form1_Activated;
        }
        private void Form1_Activated(object sender, EventArgs e)//The form gained focus
        {
            panel1.Enabled = true;
        }
        private void Form1_Deactivate(object sender, EventArgs e)// The form lost focus
        {
            panel1.Enabled = false;
        }
