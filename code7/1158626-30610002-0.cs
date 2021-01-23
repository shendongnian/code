       namespace WindowsFormsApplication1
       {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
             
            }
    
            private void compiler()
            {
                String print = TB.Text;
                if (print.ToLowerInvariant().StartsWith("print ")
                {
                  String sP = print.Substring(print.IndexOf(' ') + 1);
                  MessageBox.Show(sP, "Console");
                }
            }
    
            private void TB_TextChanged(object sender, EventArgs e)
            {
                compiler();
            }
    
            private void runToolStripMenuItem_Click(object sender, EventArgs e)
            {
                compiler();
            }
        }
        }
