        public partial class Form1 : Form
        {
            Form1 form1;
    
            public Form2()
            {    
                InitializeComponent();
            }
            public Form2(Form1 form1):this()
            {
                this.form1= form1;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                form1.AddGroup("something");
                this.Close();
            }
        }
