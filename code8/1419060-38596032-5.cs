    private void listBoxDatabase_SelectedIndexChanged(object sender, EventArgs e)
    {
    
        if (listBoxDatabase.SelectedIndex != -1)
        {
            Customer cust = listBoxDatabase.Items[listBoxDatabase.SelectedIndex] as Customer;
            tbxFirstName.Text = cust.getFirstName;
            tbxLastName.Text = cust.getLastName;
            tbxPhone.Text = cust.getPhone;
        }
    }
