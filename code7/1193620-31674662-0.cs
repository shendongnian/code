    public class MyClass
    {
        private string _currentSelectedCurrency;
        public void DdlCustomerCurrency_OnChange(object sender, EventArgs e)
        {
            if (cust.Currency.ToString() != ddlCustomerCurrency.SelectedItem.Text)
            {
                Customer.Notes.InsertNote(cust.ID, Company.Current.CompanyID, DateTime.Now, "Currency changed from '" + _currentSelectedCurrency +"' to '" + ddlCustomerCurrency.SelectedItem.Text + "'", CurrentUser.UserID, 1);
                _currentSelectedCurrency = ((DropDownList) sender).Text
            }
        }
    }
