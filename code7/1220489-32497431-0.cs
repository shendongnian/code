    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //create a list for data items
                List<MyComboBoxItem> cb1Items = new List<MyComboBoxItem>();
    
                //assign sub items
                cb1Items.Add(new MyComboBoxItem("1")
                {
                    SubItems = { new MyComboBoxItem("A"), new MyComboBoxItem("B") }
                });
    
                cb1Items.Add(new MyComboBoxItem("2")
                {
                    SubItems = { new MyComboBoxItem("C"), new MyComboBoxItem("D") }
                });
    
                cb1Items.Add(new MyComboBoxItem("3")
                {
                    SubItems = { new MyComboBoxItem("E"), new MyComboBoxItem("F") }
                });
    
                cb1Items.Add(new MyComboBoxItem("4")
                {
                    SubItems = { new MyComboBoxItem("G"), new MyComboBoxItem("H") }
                });
    
                //load data items into combobox 1
                cb1.Items.AddRange(cb1Items.ToArray());
            }
    
            private void cb1_SelectedIndexChanged(object sender, EventArgs e)
            {
                //get the combobox item
                MyComboBoxItem item = (sender as ComboBox).SelectedItem as MyComboBoxItem;
    
                //make sure no shinanigans are going on
                if (item == null)
                    return;
    
                //clear out combobox 2
                cb2.Items.Clear();
    
                //add sub items
                cb2.Items.AddRange(item.SubItems.ToArray());
            }
        }
    
        public class MyComboBoxItem
        {
            public string Name;
            public List<MyComboBoxItem> SubItems = new List<MyComboBoxItem>();
    
            public MyComboBoxItem(string name)
            {
                this.Name = name;
            }
    
            public override string ToString()
            {
                return Name;
            }
        }
