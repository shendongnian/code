    private void btnPlus_Click(object sender, EventArgs e)
    {
        HandleHoleChange(currentHole => currentHole + 1);      
    }
    private void HandleHoleChange(Func<int, int> getNextHoleFunc)
    {
        btnMinus.Enabled = true;
        if (f_intHoleNumber != 18) { f_intHoleNumber = getNextHoleFunc(f_intHoldNumber); }
        if (f_intHoleNumber == 18) { btnPlus.Enabled = false; }
        txtHoleNumber.Text = f_intHoleNumber.ToString();         
    }
    
