    List<Account> listAccount = new List<Account>();
    private void button1_Click(object sender, EventArgs e)
    {
        var account = new Account {
            CustomerID = int.Parse(customerIdTxt.Text),
            CustomerFullName = customerNameTxt.Text,
            CustomerAddress = customerAddrTxt.Text
        };
        listAccount.Add(account);
    }
    private void button6_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        foreach(var account in listAccount)
        {
            sb.AppendFormat("Customer ID: {0}\nCustomer Name: {1}\nCustomer Address: {2}\n\n", account.CustomerID, account.CustomerFullName, account.CustomerAddress);
        }
        viewDetailesTxt.Text = sb.ToString();
    }
