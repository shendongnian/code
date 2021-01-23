    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    int x = 0;
                    Int32.TryParse(comboBox1.SelectedItem.ToString(), out x);
                    int count = listBox1.Items.Count;
                    while(count > x){
                        listBox1.Items.RemoveAt(count - 1);
                        count = listBox1.Items.Count;
                    }
                }
        private void button2_Click(object sender, EventArgs e)
        {
            int x = 0;
            Int32.TryParse(comboBox1.SelectedItem.ToString(), out x);
            if (listBox1.Items.Count < x)
            {
                listBox1.Items.Add(x); //add whatever you want
            }
        }
