    int playerCardFinalTotal = 0;
    int pcFinalTotal = 0;
    private void btnChangeValue_Click(object sender, EventArgs e)
    {        
        if (rdbOne.Checked)
        {
            pcFinalTotal = playerCardFinalTotal + 1;
        }
        else if (rdbEleven.Checked)
        {
            pcFinalTotal = playerCardFinalTotal + 11;
        }
    }
