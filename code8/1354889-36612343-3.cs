    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        string prefix = searchBox.Text;
        bool found = false;
        for(int i = 0; i < listBox.Items.Count; i++)
        {
            if(listBox.Items[i].ToString().StartsWith(prefix))
            {
                listBox.SelectedItem = listBox.Items[i];
                found = true;
                break;
            }
        }
        if(!found)
        {
            MessageBox.Show("Item not found!");
        }
    }
