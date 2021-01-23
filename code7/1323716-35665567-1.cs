    void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       // get the selection
       DataRowView drv = (DataRowView)cmbCategory.SelectedItem;
       // and display the info
       txtUser.Text = drv["username"].ToString();
       txtPassword.Text = drv["password"].ToString();
    }
