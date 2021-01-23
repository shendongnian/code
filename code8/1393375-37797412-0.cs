    ControlFinder<RadioButtonList> radioButtonLists = new ControlFinder<RadioButtonList>();
    radioButtonLists.FindChildControlsRecursive(checkListTable);
    foreach (RadioButtonList rbl in radioButtonLists.FoundControls)
    {
        string id = rbl.ID;
        string value = rbl.SelectedValue;
        ...
    }
