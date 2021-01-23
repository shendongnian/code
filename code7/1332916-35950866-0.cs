    foreach (Control control in form.Controls)
    {
        if (control.Name.ToUpper().Contains("[Your control search string here]"))
        {
            // Do something here.
        }
        if (control is TextBox) {
            // Do something here.
        }
    }
