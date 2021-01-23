        private struct Item
        {
            public string Name { get; set; }
            public string Quantity { get; set; }
            public string Price { get; set; }
        }
        private List<Item> items = new List<Item>();
        private void BindTestListData()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = items;
            listBox1.DisplayMember = "Name";
            listBox2.DataSource = null;
            listBox2.DataSource = items;
            listBox2.DisplayMember = "Quantity";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputTextBox.Text))
            {
                Item newItem = new Item()
                {
                    Name = InputTextBox.Text,
                    Quantity = "1",
                    Price = "$10"
                };
                items.Add(newItem);
                InputTextBox.Clear();
                BindTestListData();
            }
        }
