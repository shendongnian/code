    foreach (Control control in Page.Controls)
    {
        DoSomething(control);
    }
    // And you need a new method to loop through the children
    private void DoSomething(Control control)
    {
        if (control.HasControls())
        {
            foreach(Control c in control.Controls)
            {
                DoSomething(c);
            }
        }
        else
        {
            var textBox = control as TextBox;
            if (textBox != null)
            {
                // Do stuff here
            }
        }
    }
