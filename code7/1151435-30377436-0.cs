    override CreateChildControls....
    {
        var secondPopupControl = (MyControlsTypeThatInheritsFromUserControl)Page.LoadControl("~/somepath/somecontrol.ascx");
        parentControlPopup.Controls.Add(secondPopupControl);
    }
