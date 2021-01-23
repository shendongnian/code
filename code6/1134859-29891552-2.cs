    int yearofpurchase,monthofpurchase,CurrentMonth,CurrentYearend;
    float Cost,DepnRate1,ad;
    bool validYearOfPurchase = int.TryParse(txtYearofPurchased.Text, out yearofpurchase);
    bool validMonthOfPurchase = int.TryParse(txtMonthofPurchased.Text, out monthofpurchase);
    bool validCurrentMonth = int.TryParse(txtCurrentMonthEnd.Text, out CurrentMonth);
    bool validCurrentYearend= int.TryParse(txtCurrentYearEnd.Text, out CurrentYearend);
    if(!validYearOfPurchase || !validMonthOfPurchas || !validCurrentMonth || !validCurrentYearend)
    {
        txtYearofPurchased.Text = "0";
        txtMonthofPurchased.Text = "0";
        txtCurrentMonthEnd.Text = "0";
        txtCurrentYearEnd.Text = "0";
    }
    else
    {
        // ...
    }
