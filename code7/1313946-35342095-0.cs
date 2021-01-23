    private void btnSearch_Click(object sender, EventArgs e)
    {
        var isResultFound = false;
        for (int i = 0; i <=listView1.Items.Count-1; i++) 
        {
            foreach(ListViewItem.ListViewSubItem subitem in listView1.Items[i].SubItems)
            {
                if (subitem.Text.Contains(txtSearch.Text))
                {
                    isResultFound = true;
                    break;
                }
                
            }
            if(isResultFound) break;
        }
        if(isItemFound)
        {
             MessageBox.Show("Found!");
        }
        else
        {
             MessageBox.Show("Not found!");
        } 
