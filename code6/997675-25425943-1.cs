    public partial class Form1 : Form
    {
        List<string> source1 = new List<string>();
        List<string> source2 = new List<string>();
        public Form1()
        {
            InitializeComponent();
            
            for (int i = 0; i < 10; i++)
            {
                source1.Add("item" + i);
                source2.Add("item" + i);
            }
            comboBox1.Items.AddRange(source1.ToArray());
            comboBox2.Items.AddRange(source2.ToArray());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains(comboBox1.SelectedItem))
            {
                comboBox2.Items.Clear();
                List<string> updatedList = new List<string>();
                updatedList = (from x in source2
                               where !x.Equals(comboBox1.SelectedItem)
                               select x).ToList<string>();
                comboBox2.Items.AddRange(updatedList.ToArray());
            }
        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox2.SelectedItem))
            {
                comboBox1.Items.Clear();
                List<string> updatedList = new List<string>();
                updatedList = (from x in source1
                               where !x.Equals(comboBox2.SelectedItem)
                               select x).ToList<string>();
                comboBox1.Items.AddRange(updatedList.ToArray());
            }
        }
 
    }
