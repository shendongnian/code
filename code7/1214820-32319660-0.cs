    public partial class Form1 : Form
    {
        public MyForm()
        {
            InitializeComponent();
            myCheckbox.CheckedChanged += new System.EventHandler(this.checkedChanged);
            myCheckbox1.CheckedChanged += new System.EventHandler(this.checkedChanged);
            myCheckbox2.CheckedChanged += new System.EventHandler(this.checkedChanged);
        }
        private void checkedChanged(object sender, EventArgs e)
        {
            myLabel.Text = "Some text";
        }
    }
        
       
    
 
