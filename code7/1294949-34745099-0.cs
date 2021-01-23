    private void snryeastTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            if (snryeastTypeComboBox.Text == "CSM")
            {
                var alcoholTolerance = 14;
                alcohol.Text = alcoholTolerance.ToString();
            }
    
        }
