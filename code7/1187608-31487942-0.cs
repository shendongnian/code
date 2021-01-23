    foreach (var control in tableLayoutPanel1.Controls.Cast<Control>())
    {
        var tb = control as TextBoxBase;
     
        if (tb != null)
            tb.ReadOnly = true;       // controls like TextBox and RichTextBox
        else
            control.Enabled = false;  // all other controls
    }
