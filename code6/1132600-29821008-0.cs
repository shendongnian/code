    public static void HideAll(this Control[] controls)
    {
        foreach(var control in controls)
        {
            control.Visible = false;
        }
    }
