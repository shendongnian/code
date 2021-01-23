    public partial class Form1 : Form
    {
        public TextBox txtOutput = new TextBox();
    
        public Form1()
        {
            InitializeComponent();
    
            this.txtOutput.Width = 200;
            this.txtOutput.Height = 100;
            this.txtOutput.Multiline = true;
            this.Controls.Add(this.txtOutput);
    
            this.txtOutput.Text = "My test\r\nNext line";
        }
    }
