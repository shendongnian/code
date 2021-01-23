    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            //Add column header
            listView1.Columns.Add("ProductName", 100);
            listView1.Columns.Add("Price", 70);
            listView1.Columns.Add("Quantity", 70);
            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;
            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            listView1.Items.Add(itm);
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text.ToLower().StartsWith(textBox1.Text.ToLower()))
                {
                    item.Selected = true;
                    item.BackColor = Color.CornflowerBlue;
                    item.ForeColor = Color.White;
                }
                else
                {
                    item.Selected = false;
                    item.BackColor = Color.White;
                    item.ForeColor = Color.Black;
                }
            }
            if (listView1.SelectedItems.Count == 1)
            {
                listView1.Focus();
            }
        }
    }
