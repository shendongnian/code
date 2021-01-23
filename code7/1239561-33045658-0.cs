    foreach(Control ctrl in this.Controls)
    {
        if(ctrl.GetType() == typeof(TextBox))
        {
            ctrl.Text = String.Empty;
        }
    }
