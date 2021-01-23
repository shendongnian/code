    public partial class Form3 : Form
    {
        string myData;
        public Form3()
        {
            InitializeComponent();
        }
        public string getData
        {
            get
            {
                return myData;
            }
            set
            {
                myData = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
