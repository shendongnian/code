    if(!string.IsNullOrEmpty(txbPhoneNumber.Text))
    {
        ri.DialingCodeID = Convert.ToInt32(ddlDialingCode.SelectedValue);
        ri.DialingCode = ddlDialingCode.SelectedValue;
        ri.DialingCodeText = ddlDialingCode.SelectedItem.Text;
    }
    else
    {
        ri.DialingCodeID = 0;
        ri.DialingCode = "0";
        ri.DialingCodeText = "";
    }
