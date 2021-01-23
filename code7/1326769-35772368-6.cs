    public partial class Form2 : Form
        {
            public Form1 f1 { get; set; }
    
            public Form2()
            {
                InitializeComponent();
            }
    
            private void btnMigrate_Click(object sender, EventArgs e)
            {
                if (this.f1 == null || this.f1.IsDisposed == true)
                {
                    this.f1 = new Form1();
                    this.f1.f2 = this;
                }
                f1.Show();
                this.Hide();
    
            }
        }
