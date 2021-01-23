        private List<string> testList = new List<string>();
        private void BindTestListData()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = testList;
            listBox2.DataSource = null;
            listBox2.DataSource = testList;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputTextBox.Text))
            {
                testList.Add(InputTextBox.Text);
                InputTextBox.Clear();
                BindTestListData();
            }
        }
