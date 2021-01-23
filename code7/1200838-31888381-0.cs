    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListBoxes();
        }
        private void InitializeListBoxes()
        {
            //Populate listboxes
            listBox1.Items.Add("Apple");
            listBox1.Items.Add("Orange");
            listBox1.Items.Add("Mango");
            listBox2.Items.Add("Milk");
            listBox2.Items.Add("Cheese");
            listBox2.Items.Add("Butter");
            listBox3.Items.Add("Coffee");
            listBox3.Items.Add("Cream");
            listBox3.Items.Add("Sugar");
            //Subscribe to same events
            listBox1.SelectedIndexChanged += listBox_SelectedIndexChanged;
            listBox2.SelectedIndexChanged += listBox_SelectedIndexChanged;
            listBox3.SelectedIndexChanged += listBox_SelectedIndexChanged;
        }
        void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            listBox1.SelectedIndex = listBox.SelectedIndex;
            listBox2.SelectedIndex = listBox.SelectedIndex;
            listBox3.SelectedIndex = listBox.SelectedIndex;
        }
    }
