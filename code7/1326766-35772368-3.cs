    public partial class Form1 : Form
    {
        public Form2 f2 { get; set; }
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnMigrate_Click(object sender, EventArgs e)
        {
            if (this.f2 == null || this.f2.IsDisposed == true)
            {
                this.f2 = new Form2();
                this.f2.f1 = this;
            }
            f2.Show();
            this.Hide();
        }
    }
