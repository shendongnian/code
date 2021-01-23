    Control ctrl = Page.FindControl(CtrlId);
    if (ctl is RadioButton)
    {
        RadioButton rdBtn = ctrl as RadioButton;
        // now do whatever here
        if(rdBtn.Checked)
        {
        }
    }
