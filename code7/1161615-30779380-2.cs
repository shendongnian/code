    //Integer input CustomControl with validation label (pictured above)
    public partial class intTextBox : UserControl
    {
        public bool IsValid {get;set;}
        public intTextBox()
        {
            InitializeComponent();
            this.textBox1.TextChanged += this.intTextBox_TextChanged;
        }
    
        private void intTextBox_TextChanged(object sender, EventArgs e)
        {
            int n;
            IsValid = int.TryParse(this.textBox1.Text, out n);
            label1.Visible = !IsValid;
        }
    }
