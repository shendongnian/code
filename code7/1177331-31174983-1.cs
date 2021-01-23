    protected void btnAdd_Click(object sender, EventArgs e)
    {
        while(lstMain.SelectedItems.Count > 0)
        {
            var list = lstMain.SelectedItems[0];
            lstFAvourite.ClearSelection();
            lstFAvourite.Items.Add(list);
            lstMain.Items.Remove(list);
        }
    }
