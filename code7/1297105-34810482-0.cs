    if (!string.IsNullOrEmpty(txtBoxFatherHusbandName.Text) || !string.IsNullOrEmpty(txtBoxName.Text) || !string.IsNullOrEmpty(txtBoxNICNo.Text))
        {
            ShowMsgBox("Please first <b>Save/Update</b> the data being entered in mandatory fields");
            txtBoxFatherHusbandName.Focus();
            return;
        }
