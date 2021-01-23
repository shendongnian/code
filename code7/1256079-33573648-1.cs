    public void OKBtn_Click(object sender, EventArgs e)
    {
        // assume a Control is the sender
        var ctrl = (Control)sender;
        // on which form is the control?
        var frm = ctrl.FindForm();
        // iterate over all controls
        DomainUpDown domainUpDown = null;
        foreach(var ctr in frm.Controls)
        {
            // check if this is the correct control
            if (ctr is DomainUpDown)
            {
                // store it's reference
                domainUpDown = (DomainUpDown)ctr;
                break;
            }
        }
        // if we have found the control
        if (domainUpDown != null)
        {
            textArea.SelectionLength = 0;
            Debug.WriteLine(domainUpDown.SelectedIndex);
            Debug.WriteLine(domainUpDown.SelectedItem);
            // use the SelectedItem
            textArea.SelectedText = string.Format("margin-top: {0} ; \n,", domainUpDown.SelectedItem );
        }
    }
