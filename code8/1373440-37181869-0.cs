    private void btnTotalRevenue_Click(object sender, EventArgs e)
    {
        dt = db.selectDates(pickerDateFrom.SelectedDate.Value.ToString("#yyyy/MM/dd#"), pickerDateTo.SelectedDate.Value.ToString("#yyyy/MM/dd#"));
        string a = dt.Rows[0]["Price"].ToString();
        MessageBox.Show(a);   
    } 
