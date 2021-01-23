    public partial class Form1 : Form
        {
            private BusinessLayer _businessLayer ;
    
            public Form1()
            {
                InitializeComponent();
                _businessLayer = new BusinessLayer();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var categories = _businessLayer.GetCategories();
                comboBox1.DataSource = categories;
            }
        }
