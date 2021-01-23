    private void btnSearch_Click(object sender, EventArgs e)
    {
        var isResultFound =  listView1.Items.Any(i=>
                   i.SubItems.Any(si=>
                       si.Text.Contains(txtSearch.Text)));
  
        if(isItemFound)
        {
             MessageBox.Show("Found!");
        }
        else
        {
             MessageBox.Show("Not found!");
        } 
