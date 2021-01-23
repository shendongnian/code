    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string Content { get; private set; }
        public void ButtonOkOnClick()
        {
            this.Content = this.textBox1.Text;
            this.Close();
        }
    }
