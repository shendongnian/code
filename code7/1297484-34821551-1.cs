    public partial class Form2 : Form
    {
        public List<string> FirstNames { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(List<string> firstNames)
        {
            InitializeComponent();
            this.FirstNames = firstNames;
            this.Shown += Form2_Shown;
        }
    
        private void Form2_Shown(object sender, EventArgs e)
        {
            listBox1.DataSource = this.FirstNames;
        }
    }
