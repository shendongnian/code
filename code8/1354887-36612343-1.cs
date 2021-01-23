    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        string prefix = searchBox.Text;
        bool found = false;
        foreach(var item in listBox.Items)
        {
            if(item.ToString().StartsWith(prefix))
            {
                listBox.SelectedItem = item;
                found = true;
                break;
            }
        }
        if(!found)
        {
            MessageBox.Show("Item not found!");
        }
    }
