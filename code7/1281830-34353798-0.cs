    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ChildFrm.MyEvent += new EventHandler(HandleTheEvent);
        }
        ChildForm ChildFrm = new ChildForm();
        private void button1_Click(object sender, EventArgs e)
        {
            ChildFrm.ShowDialog();
        }
        public void HandleTheEvent(object sender, EventArgs e)
        {
            textBox1.Text = "event is fired";
        }
    }
