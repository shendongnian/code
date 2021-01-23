    private void listbox_MouseDown(object sender, MouseEventArgs e)
    {
        ShowMenuStrip = listbox.IndexFromPoint(e.Location) >= 0; //This is a global bool variable
        if (ShowMenuStrip)
           listbox.SelectedIndex = listbox.IndexFromPoint(e.Location);
        else
           listbox.SelectedIndex = -1;          
    }
    private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
        e.Cancel = !ShowMenuStrip;
    }
