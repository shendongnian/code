    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 6; i <= 10; i++)
            {
                listBox1.Items.Add("item" + i);
            }
            for (int i = 1; i <= 5; i++)
            {             
                listBox2.Items.Add("item" + i);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            /// write here the code that save listbox1 and listbox2 items
            /// to a text file or a database table and load this text file or 
            /// the database table inside these two listboxes you could write the 
            /// code that load data to the two list boxes in the constructor instead
            /// of the two for loops thats i've provided.s
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!listBox2.Items.Contains(listBox1.SelectedItem))
                {
                    listBox2.Items.Add(listBox1.SelectedItem);
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Item already exists");
                }
            }
            catch (ArgumentNullException exc)
            {
                MessageBox.Show("Nothing selected to add");
               
            }         
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (!listBox1.Items.Contains(listBox2.SelectedItem))
                {
                    listBox1.Items.Add(listBox2.SelectedItem);
                    listBox2.Items.Remove(listBox2.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Item already exists");
                }
            
            }
            catch (ArgumentNullException exc)
            {
                MessageBox.Show("Nothing selected to remove");
            }
            
        }
    }
