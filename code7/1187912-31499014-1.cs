    public Form1()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel3.Visible = false;
            panel2.Visible = false;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
            }
            else if (panel2.Visible)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else if (panel3.Visible)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
        }
