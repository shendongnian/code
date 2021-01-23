    private void chbFilter_CheckedChanged(object sender, EventArgs e)
    {
        string filter = "";
        if (chbAktivan.Checked)
            filter += "ExpirationDate >= '{0}'," + DateTime.Today;
        if (chbNeaktivan.Checked)
        {
            filter += OR(filter);
            filter += "ExpirationDate < '{0}'," + DateTime.Today;
        }
        bs.Filter = string.Format(filter);
    }
 
