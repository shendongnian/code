    if (cust.CountryName.ToString() != ddlCountry.SelectedItem.Text)
    {
        Customer.Notes.InsertNote(cust.ID, Company.Current.CompanyID, DateTime.Now, "Country changed from '" + cust.CountryName + "' to '" + ddlCountry.SelectedItem.Text + "'", CurrentUser.UserID, 1);
        HasChanges = true;
    }  
