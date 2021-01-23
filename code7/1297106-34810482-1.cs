    if (!string.IsNullOrWhiteSpace(txtBoxFatherHusbandName.Text) || !string.IsNullOrWhiteSpace(txtBoxName.Text) || !string.IsNullOrWhiteSpace(txtBoxNICNo.Text))
        {
            ShowMsgBox("Please first <b>Save/Update</b> the data being entered in mandatory fields");
            txtBoxFatherHusbandName.Focus();
            return;
        }
