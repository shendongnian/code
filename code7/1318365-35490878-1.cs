        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
                textBox1.Text = listBox1.SelectedItem.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.Items.IndexOf(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
            listBox1.Items.Insert(index, textBox1.Text);            
        }
