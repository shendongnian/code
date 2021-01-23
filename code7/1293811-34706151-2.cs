     public partial class Form1
            : Form
        {
            private readonly ShortTextService _shortTextService;
    
            public Form1()
            {
                _shortTextService = new ShortTextService();
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                richTextBox1.Text = _shortTextService.GetShortText(NameTextBox.Text);//here NameTextBox is input for the name 
            }
        }
