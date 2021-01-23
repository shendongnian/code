    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void PopulateListBox(params CheckBox[] checkboxes)
        {
            foreach(var item in checkboxes.Where((cb) => cb.Checked))
            {
                listBox1.Items.Add(item.Text);
            }
        }
    }
