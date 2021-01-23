    private void ClearControls(ControlCollection controlCollection, bool ignoreddlNewOrExisting = false)
    {
        foreach (Control control in controlCollection)
        {
            if (ignoreddlNewOrExisting)
            {
                if (control.ID != null)
                {
                    if (control.ID.ToUpper() == "DDLNEWOREXISTING")
                    {
                        continue;
                    }
                }
            }
            if (control is TextBox)
            {
                ((TextBox)control).Text = "";
                ((TextBox)control).Font.Size = 10;
            }
            if (control is DropDownList)
            {
                ((DropDownList)control).SelectedIndex = 0;
                ((DropDownList)control).Font.Size = 10;
            }
            if (control is CheckBox)
            {
                ((CheckBox)control).Checked = false;
            }
            //A bit of recursion
            if (control.Controls != null)
            {
                this.ClearControls(control.Controls, ignoreddlNewOrExisting);
            }
        }
    }
