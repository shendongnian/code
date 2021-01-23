        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTextBox1(); 
        }
        private void updateTextBox1()
        {
            textBox1.Text = Convert.ToString(listBox1.SelectedIndex);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = (listBox1.SelectedIndex + 1) % listBox1.Items.Count;
            listBox1_SelectedIndexChanged(sender, e);
        }
