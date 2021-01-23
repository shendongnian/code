    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Global.f2.Hide();
            Global.f1.Hide();
            Global.f1.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Global.f1.Hide();
            Global.f2.Hide();
            Global.f2.Show();
        }
        public void SetForm1(Form form)
        {
            Global.f1 = form;
        }
        public void SetForm2(Form form)
        {
            Global.f2 = form;
        }
    }
