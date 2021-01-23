    private void FillInTextFields(DataTable table, int ind)
    {
        dataRow = table.Rows[ind];
        txtNHSNumber.Text = dataRow[0].ToString();
        txtFirstName.Text = dataRow[1].ToString();
        txtLastName.Text = dataRow[2].ToString();
        txtTimeDate.Text = dataRow[3].ToString();
        txtHeartRate.Text = dataRow[4].ToString();
        txtTemp.Text = dataRow[5].ToString();
        txtReps.Text = dataRow[6].ToString();
        txtDia.Text = dataRow[7].ToString();
        txtSys.Text = dataRow[8].ToString();
    }
