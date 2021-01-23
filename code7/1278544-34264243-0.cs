      private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                while (listBox1.SelectedItems.Count > 0)
                {
                    listBox2.Items.Add(listBox2.SelectedItem);
                    listBox1.Items.Remove(listBox2.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }
