      private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
            {
                comboBox1.Items.Add(comboBox1.Text);
                comboBox1.Items.RemoveAt(comboBox1.Items.Count - 2);
            }
        }
