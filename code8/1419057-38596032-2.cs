    private void btnAddCustomer_MouseClick(object sender, EventArgs e)
    {
        Customer cust = new Customer(tbxFirstName.Text, tbxLastName.Text, tbxPhone.Text);
    
        if (listBoxDatabase.Items.Contains(cust.ToString()))
        {
            MessageBox.Show("Customer Already Exist!", "ERROR");
        }
        else
        {
            // Add a customer, not its ToString representation
            listBoxDatabase.Items.Add(cust);
        }
    }
