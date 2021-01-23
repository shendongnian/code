    if (cbWithRoute.Checked)
    {
        // StartSearch(txtRoute.SelectedValue.ToString());
        MessageBox.Show(@"route");
        return;
    }
    if (cbWithRoute.Checked && cbWithWholeSeller.Checked)
    {
        //StartSearch(txtRoute.SelectedValue.ToString(), txtWholeSeller.SelectedValue.ToString());
        MessageBox.Show(@"route wholeseller");
        return;
    }
