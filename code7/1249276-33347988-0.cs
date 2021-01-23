     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UI CustomUI = new UI();
            CustomUI.set_lbl_txt = "Text";
        }
    }
     public partial class UI : UserControl
    {
        public UI()
        {
            InitializeComponent();
        }
        public string set_lbl_txt
        {
            get { return lbl_text.Text; }
            set
            {
                lbl_text.Text = value;
            }
        }
    }
