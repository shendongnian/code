    public partial class Form1 : Form
    {
        public delegate void dMyFunction(string param);
        public dMyFunction delMyFunction;
        public Form1()
        {
            InitializeComponent();
            delMyFunction = new dMyFunction(this.MyFunction);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        private void MyFunction(string param)
        {
            this.Text = param;
        }
    }
