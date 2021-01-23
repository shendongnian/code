    CheckBox chk = new CheckBox();
    chk.ID = "chkRoles";
    chk.Text = "Check";
    PlaceHolder1.Controls.Add(chk);
    chk.Attributes.Add("onclick", "changeCheckboxText(this)");
