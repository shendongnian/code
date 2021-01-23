    public partial class Form2 : Form
    {
        string _input;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string input)
        {
            _input = input;
            InitializeComponent();
            this.label1.Text = _input;
        }
    }
