    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
            private void chk_Click(object sender, EventArgs e)
            {
                int x = Convert.ToInt32(num.Text);
                if (x%2 == 0)
                {
                    chkd.Text = "Even";
                }
                else
                {
                    chkd.Text = "Odd";
                }
            }
        
            private void num_TextChanged(object sender, EventArgs e)
            {
        
            }
        }
    }
 
