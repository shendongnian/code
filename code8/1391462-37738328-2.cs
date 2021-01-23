    private RadioButton selectedRadioButton = rdoViewAll;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (rdoViewCurrent.Checked)
        {
            selectedRadioButton = rdoViewCurrent;
        }
                
        if (rdoViewFuture.Checked)
        {
            selectedRadioButton = rdoViewFuture;
        }
                
        rdoViewAll.Checked = false;
        rdoViewCurrent.Checked = false;
        rdoViewFuture.Checked = false;
    
        ClientScript.RegisterStartupScript(GetType(), "InitRadio", string.Format("document.getElementById('{0}').checked = true;", selectedRadioButton.ClientID), true);
    }
