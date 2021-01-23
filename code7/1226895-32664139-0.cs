       public Form1()
            {
                InitializeComponent();
                List<string> items = new List<string>();
                items.Add("sachin");
                items.Add("dravid");
                items.Add("ganguly");
                cmbSample.DataSource = items;
            }
    
            private void cmbSample_SelectedValueChanged(object sender, EventArgs e)
            {
                lstSample.Items.Clear();
                lstSample.Items.Add(cmbSample.SelectedItem);
                lstSample.SelectedItem = cmbSample.SelectedItem;
            }
