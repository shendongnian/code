    public partial class Form1 : Form
    {
        public ViewModel ViewModel = new ViewModel();
        public Form1()
        {
            InitializeComponent();
            // Connect:  textBox1.Text <-> viewModel.TextFieldValue
            textBox1.DataBindings.Add("Text", ViewModel , "TextFieldValue");
        }
    }
