    protected void btnSelectOne_Click(object sender, EventArgs e)
    {
      lstDest.Items.Add(lstSource.SelectedItem);
    }
    
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
      foreach (ListItem item in lstSource.Items)
      {
        lstDest.Items.Add(item);
      }
    }
