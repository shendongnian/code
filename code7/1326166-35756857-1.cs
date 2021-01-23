    var customer = context.Customers.Find(txtId.Text);
    if (customer != null)
    {
        txtFirstName.Text = customer.FirstName;
        txtlastName.Text = customer.LastName;
        txtEmail.Text = customer.Email;
        txtPhone.Text = customer.Phone;
        cboCountry.SelectedValue = customer.CountryId;
    }
