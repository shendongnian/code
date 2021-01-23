    public partial class Form3 : Form
    {
        public int Index { get; set; }
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = Index;
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Index = comboBox1.SelectedIndex;
        }
    }
