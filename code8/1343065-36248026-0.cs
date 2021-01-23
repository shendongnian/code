    public partial class Form1 : Form
        {   
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string output = "test";
                File.WriteAllText(@"C:\output.txt", output)
            }
    private void combobox1_SelectedItemChanged
            {
                string output = File.ReadAllText(@"C:\output.txt")
                // do something with this string
            }
        }
