    if (txtYearofPurchased.Text == null || 
         txtMonthofPurchased.Text == null || 
         txtCurrentMonthEnd.Text == null || 
         txtCurrentYearEnd.Text == null|| 
         txtCost.Text == null || 
         txtDepnRate1.Text ==null)
    {
            txtYearofPurchased.Text = Convert.ToString(0);
            txtMonthofPurchased.Text = Convert.ToString(0);
            txtCurrentMonthEnd.Text= Convert.ToString(0);
            txtCost.Text= Convert.ToString(0);
            txtDepnRate1.Text = Convert.ToString(0);
    }
    int yearofpurchase = Int32.Parse(txtYearofPurchased.Text);
    int monthofpurchase = Int32.Parse(txtMonthofPurchased.Text);
    int CurrentMonth = Int32.Parse(txtCurrentMonthEnd.Text);// present month
    int CurrentYearend = Int32.Parse(txtCurrentYearEnd.Text);// present year
    float Cost = Int32.Parse(txtCost.Text);
    float DepnRate1 = Int32.Parse(txtDepnRate1.Text) / 100;
    float ad = AD();
