    private void FillInTextFields(DataTable table, int ind)
    {
        txtNHSNumber.Text = table.Rows[0].ItemArray[0];
        txtFirstName.Text = table.Rows[0].ItemArray[1];
        txtLastName.Text = table.Rows[0].ItemArray[2];
        txtTimeDate.Text = table.Rows[0].ItemArray[3];
        txtHeartRate.Text = table.Rows[0].ItemArray[4];
        txtTemp.Text = table.Rows[0].ItemArray[5];
        txtReps.Text = table.Rows[0].ItemArray[6];
        txtDia.Text = table.Rows[0].ItemArray[7];
        txtSys.Text = table.Rows[0].ItemArray[8];
    }
            
