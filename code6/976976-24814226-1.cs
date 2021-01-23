    if (control is CheckBox)
    {
        if (control.Tag != null && ((bool)control.Tag) == false)
        {
            continue;
        }
        CheckBox checkBox = (CheckBox)control;
        checkBox.Checked = false;
    }
