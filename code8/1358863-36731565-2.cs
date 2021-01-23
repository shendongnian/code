    ControlFinder<CheckBox> finder = new ControlFinder<CheckBox>();
    finder.FindChildControlsRecursive(lvUsers);
    
    foreach (CheckBox chkBox in finder.FoundControls)
    {
        if (chkBox.Checked && chkBox.ValidationGroup == "userCheck")
        {
            // Do something
        }
    }
