    private class TestClass
        {
            public int Id
            {
                get;
                set;
            }
            public string Text
            {
                get;
                set;
            }
            public string Detail
            {
                get;
                set;
            }
        }
        private void ListViewSearch_Load(object sender, EventArgs e)
        {
            List<TestClass> source = new List<TestClass>();
            source.Add(new TestClass { Id = 1, Text = "one", Detail = "D1" });
            source.Add(new TestClass { Id = 2, Text = "two", Detail = "D2" });
            source.Add(new TestClass { Id = 3, Text = "three", Detail = "D1" });
            source.Add(new TestClass { Id = 4, Text = "four", Detail = "D3" });
            source.Add(new TestClass { Id = 5, Text = "five", Detail = "D6" });
            source.Add(new TestClass { Id = 6, Text = "5", Detail = "D6" });
            listView1.Columns.Add("Id");
            listView1.Columns.Add("Text");
            listView1.Columns.Add("Detail");
            source.ForEach(x =>
            {
                ListViewItem item = new ListViewItem(x.Id.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(x.Text);
                item.SubItems.Add(x.Detail);
                listView1.Items.Add(item);
            });
            listView1.View = View.Details;
            listView1.GridLines = true;
            comboBox1.DataSource = listView1.Columns;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Text";
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    for (int subItemIndex = 0; subItemIndex < item.SubItems.Count; subItemIndex++)
                    {
                        if (subItemIndex == comboBox1.SelectedIndex && item.SubItems[subItemIndex].Text.Contains(textBox1.Text))
                        {
                            item.SubItems[subItemIndex].BackColor = SystemColors.Highlight;
                            item.SubItems[subItemIndex].ForeColor = SystemColors.HighlightText;
                        }
                        else
                        {
                            item.SubItems[subItemIndex].BackColor = Color.Transparent;
                            item.SubItems[subItemIndex].ForeColor = SystemColors.WindowText;
                        }
                    }
                }
            }
        }
