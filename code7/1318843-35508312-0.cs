    public partial class Form1 : Form
    {
        ArrayList Table1;
        ArrayList Table2;
        bool isSaved = false;
        public Form1()
        {
            InitializeComponent();
            Table1 = new ArrayList();
            Table2 = new ArrayList();
            Table1.Add("Value1");
            Table1.Add("Value2");
            Table1.Add("Value3");
            Table1.Add("Value4");
            Table1.Add("Value5");           
        }
        private void populateListBox1() {
            for (int i = 0; i < Table1.Count;i++)
            {
                listBox1.Items.Add(Table1[i]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            populateListBox1();          
        }
        private void refreshListBox1() {
            listBox1.Items.Clear();
            populateListBox1();  
        }
        private void addToRight() {
            try
            {
                listBox2.Items.Add(Table1[listBox1.SelectedIndex]);
                Table1.RemoveAt(listBox1.SelectedIndex);
            }
            catch 
            {
                MessageBox.Show("You have to select an item first !");
            }
           
            refreshListBox1();
        }
        private void removeFromRight(){
            if (isSaved)
            {
                try
                {
                    listBox1.Items.Add(Table2[listBox2.SelectedIndex]);
                    Table1.Add(Table2[listBox2.SelectedIndex]);
                    isSaved = false;
                }
                catch 
                {
                    MessageBox.Show("You have to select an item first !");
                    isSaved = true;
                }
                try
                {
                    Table2.RemoveAt(listBox2.SelectedIndex);
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    isSaved = false;
                }
                catch 
                {
                    if(listBox2.Items.Count==0)
                    MessageBox.Show("This list is an empty list");
                    isSaved = true;
                }
                
            }
            else {
                MessageBox.Show("You have to click save button first !");
            }
           
        }
        private void saveToTable2() {
            for (int i = 0; i < listBox2.Items.Count;i++)
            {
                Table2.Add(listBox2.Items[i].ToString());
            }
            MessageBox.Show("Saved !");
            isSaved=true;           
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            addToRight();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            saveToTable2();           
        }
        private void btn_remove_Click(object sender, EventArgs e)
        {
            removeFromRight();
        }
    }
}
