    foreach (Control control in controls)
    {
        if (control is TextBox)
        {
        }
        else if (control is Checkbox)
        {
        }
        else if (control.Controls.Count > 0)
        {
            FindMyControls(control.Controls);
        }
    }
}
