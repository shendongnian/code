        private string[] listItem = { "a", "b", "c", "d", "e", "f","g","h","i" };
        private List<string> selectedItem = new List<string>();
        public Form1()
        {
            InitializeComponent();
            LoadItem();
        }
        private void LoadItem() 
        {
            for (int i = 0; i < listItem.Count(); i++)
            {
                lstItem.Items.Add(listItem[i]);
            }
        }
        private void btnGetSelectedItem_Click(object sender, EventArgs e)
        {
            int CountSelectedItem = lstItem.SelectedItems.Count; 
            for (int i = 0; i < CountSelectedItem; i++)
            {
                string text = lstItem.SelectedItems[i].ToString();
                selectedItem.Add(text);   
            }
            for (int i = 0; i < selectedItem.Count; i++)
            {
                txtSelectedItem.Text = txtSelectedItem.Text + "," + selectedItem[i]; 
            }
        }
