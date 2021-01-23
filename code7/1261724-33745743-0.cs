    private void FillInTextFields(DataTable table, int ind)
    {
        dataRow = table.Rows[ind];
        txtNHSNumber.Text = dataRow.ItemArray.GetValue(0).ToString();
        txtFirstName.Text = dataRow.ItemArray.GetValue(1).ToString();
        txtLastName.Text = dataRow.ItemArray.GetValue(2).ToString();
        txtTimeDate.Text = dataRow.ItemArray.GetValue(3).ToString();
        txtHeartRate.Text = dataRow.ItemArray.GetValue(4).ToString();
        txtTemp.Text = dataRow.ItemArray.GetValue(5).ToString();
        txtReps.Text = dataRow.ItemArray.GetValue(6).ToString();
        txtDia.Text = dataRow.ItemArray.GetValue(7).ToString();
        txtSys.Text = dataRow.ItemArray.GetValue(8).ToString();
    }
