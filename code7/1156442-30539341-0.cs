    //Clears TextBox
    if (ctrl is System.Web.UI.WebControls.TextBox)
    {
        (ctrl as TextBox).Text = "";
    }
    //Clears DropDown Selection
    if (ctrl is System.Web.UI.WebControls.DropDownList)
    {
        (ctrl as DropDownList).ClearSelection();
    }
    //Clears ListBox Selection
    if (ctrl is System.Web.UI.WebControls.ListBox)
    {
        (ctrl as ListBox).ClearSelection();
    }
    //Clears CheckBox Selection
    if (ctrl is System.Web.UI.WebControls.CheckBox)
    {
        (ctrl as CheckBox).Checked = false;
    }
    //Clears RadioButton Selection
    if (ctrl is System.Web.UI.WebControls.RadioButtonList)
    {
        (ctrl as RadioButtonList).ClearSelection();
    }
    //Clears CheckBox Selection
    if (ctrl is System.Web.UI.WebControls.CheckBoxList)
    {
        (ctrl as CheckBoxList).ClearSelection();
    }
}
