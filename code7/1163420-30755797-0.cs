    string customerNameTB = customerNameTextbox.Text;  
    // single quotes
    customerNameTB = customerNameTB.Replace("'", "''");
    // triple quotes
    customerNameTB = customerNameTB.Replace("'''", "''");
