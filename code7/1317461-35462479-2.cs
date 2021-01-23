    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void comboBox1_MouseLeave(object sender, EventArgs e)
            {
              var comboBox = sender as ComboBox;
    
              this.TestMethod(comboBox);
            }
    
            private void TestMethod(ComboBox d)
            {
                var list = new List<string>() {"hi", "hello", "whats up"};
                d.DataSource = list;
                d.SelectedItem = null;
            }
        }
