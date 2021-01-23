    void btnTotalRevenue_Click(object sender, EventArgs e)
    {
        dt = db.selectDates(pickerDateFrom.Value, pickerDateTo.Value);
        string a = dt.Rows[0]["Price"].ToString();
        MessageBox.Show(a);
    }
