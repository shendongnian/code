    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 myForm2 = new Form2();
            // Do not use this line if you handle looping through the controls
            // in your combobox1_SelectedIndexChanged method.
            comboBox1.SelectedIndexChanged += myForm2.HandlerForIndexChanges;
                        
            myForm2.Show();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This handles the selection change.
            foreach (Form2 cont in panel4.Controls.OfType<Form2>())
            {
                cont.SomeOtherWay("Some", "Other", "Way");
            }
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void HandlerForIndexChanges(object o, EventArgs e)
        {
            // I can handle the event change here for my form as well.
        }
        public void SomeOtherWay(string st, string st2, string st3)
        {
            // Access to more data!!!
        }
    }
