     public partial class  PhysicalChild : Form
        {
            public  PhysicalChild()
            {
                InitializeComponent();
            }
    
            private void PhysicalChild_Load(object sender, EventArgs e)
            {
                MessageBox.Show(this.MdiParent.Text );
            }
        }
