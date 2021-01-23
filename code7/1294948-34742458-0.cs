    public void snryeastTypeComboBox_TextChanged(object sender, EventArgs e)
    {
        if (snryeastTypeComboBox.Text == "CSM")
        {
            var alcoholTolerance = 14;
            alcohol.Text = alcoholTolerance.ToString();
        }
