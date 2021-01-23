    public static void MoveForm(this Form form, Screen screen = null)
    {
        if(screen == null)
        {
            //If we have a single screen, we are not moving the form
            if(Screen.AllScreens.Length > 1) return;
            
            screen = Screen.AllScreens[1];
        }
        var bounds = screen.Bounds;
    
        form.Left = ((bounds.Left + bounds.Right) / 2) - (form.Width / 2);
        form.Top = ((bounds.Top + bounds.Bottom) / 2) - (form.Height / 2);            
    }
