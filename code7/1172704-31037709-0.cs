    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form1 OtherForm { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            string value = OtherForm.value;
            ...
