    if (String.IsNullOrWhitespace(txtYearofPurchased.Text) || 
        String.IsNullOrWhitespace(txtMonthofPurchased.Text) || 
        String.IsNullOrWhitespace(txtCurrentMonthEnd.Text) || 
        String.IsNullOrWhitespace(txtCurrentYearEnd.Text) || 
        String.IsNullOrWhitespace(txtCost.Text) || 
        String.IsNullOrWhitespace(txtDepnRate1.Text))
    {
        txtYearofPurchased.Text = "0";
        txtMonthofPurchased.Text = "0";
        txtCurrentMonthEnd.Text= "0";
        txtCost.Text= "0";
        txtDepnRate1.Text = "0";
    }
    int yearofpurchase = Int32.Parse(txtYearofPurchased.Text);
    int monthofpurchase = Int32.Parse(txtMonthofPurchased.Text);
    int CurrentMonth = Int32.Parse(txtCurrentMonthEnd.Text);// present month
    int CurrentYearend = Int32.Parse(txtCurrentYearEnd.Text);// present year
    float Cost = Int32.Parse(txtCost.Text);
    float DepnRate1 = Int32.Parse(txtDepnRate1.Text) / 100;
