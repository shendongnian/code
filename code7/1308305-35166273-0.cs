    private void btnAdd2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Multiple Items");
            }
            else
            {
                if (!listBox2.Items.Contains(listBox1.SelectedItem))
                {
                    foreach (var item in listBox1.SelectedItems)
                    {
                        listBox2.Items.Add(item);
                    }
                }
            }
        }
