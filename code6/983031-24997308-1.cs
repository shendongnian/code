    public void ChangeUIPropertys(Control UIObject , Color color , string Text)
    {
        // to make whole operation thread safe
        
        var action = delegate {
            // to check control type
            if (control is TextBox)
            {
                var tb = (TextBox)control;
                // apply changes
                
            }
            else if (control is Label)
            {
                 // do the same
            }
        };
        
        if (control.InvokeRequired)
            control.Invoke(action);
        else
            action.Invoke();
        
    }
