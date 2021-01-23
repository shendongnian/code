    if(checksBox.CheckState == CheckState.Checked)
    {
        if(OriginalMain.temporaryChecks >= x)
        {
            return true;
        }
        else
        {
            MessageBox.Show("Error! Insufficient funds");
            return false;
        }
    }
    if(savingsBox.CheckState == CheckState.Checked)
    {
        if(OriginalMain.temporarySavings >= x)
        {
            return true;
        }
        else
        {
            MessageBox.Show("Error! Insufficient funds!");
            return false;
        }
    }
