    private void btnAddCustomer_MouseClick(object sender, EventArgs e)
    {
        Customer cust = new Customer(tbxFirstName.Text, tbxLastName.Text, tbxPhone.Text);
    
        // This will replace the Contains because now you have 
        // a collection of Customer not a collection of strings.
        if (listBoxDatabase.Items.Cast<Customer>()
                           .Any(x => x.ToString() == cust.ToString())) 
        {
            MessageBox.Show("Customer Already Exist!", "ERROR");
        }
        else
        {
            // Add a customer, not its ToString representation
            listBoxDatabase.Items.Add(cust);
        }
    }
