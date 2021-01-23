    namespace WindowsFormsApplication1
    {
        public partial class Form2 : Form
        {   
            internal string name; //THIS LINE HERE CHANGED TO SET THE TYPE
            public Form2(string name)
            {
                this.name = name; //NEED THIS LINE TO SET THE VARIABLE
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show(name); //SHOW THE NAME
            }
        }
    }
