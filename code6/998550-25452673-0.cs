    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = new BindingSource(new Dictionary<string, List<string>>
            {
                {"Four-Legged Mammals", new List<string>{"Cats", "Dogs", "Pigs"}},
                {"Two-Legged Mammals", new List<string>{"Humans", "Chimps", "Apes"}}
            }, null);
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var keyValue = (KeyValuePair<string, List<String>>) listBox1.SelectedItem;
                listBox2.DataSource = keyValue.Value;
            }
            else
            {
                listBox2.DataSource = null;
            }
        }
