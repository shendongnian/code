    private void btnChangeValue_Click(object sender, EventArgs e)
    {            
        if (rdbOne.Checked == true)
        {
            playerTallyTotals(-1);
            rdbOne.Checked = false;
            pnlValues.Enabled = true;
        }
        else if (rdbEleven.Checked == true)
        {
            playerTallyTotals(-11);
            rdbEleven.Checked = false;
            pnlValues.Enabled = true;
        }
    }
