    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Choose from list.";
            comboBox1.Items.Add("Test1");
            comboBox1.Items.Add("Test2");
            comboBox1.Items.Add("Test3");
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && comboBox1.DroppedDown)
            {
                //Remove the listitem from the combobox list
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
    
                //Make sure no other processing happens, ex: deleting text from combobox
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down && !comboBox1.DroppedDown)
            {
                //If the down arrow is pressed show the dropdown list from the combobox
                comboBox1.DroppedDown = true;
            }
        }
    }
