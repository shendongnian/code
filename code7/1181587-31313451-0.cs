            private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
            {
                MessageBox.Show(item.ToString()); //This gets the displayed name of the checked items
            }
            foreach (var item in checkedListBox1.CheckedIndices)
            {
                MessageBox.Show(item.ToString()); //This Displays the index of the checked items
            }
        }
