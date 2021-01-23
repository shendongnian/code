        UserControl tmp;
        foreach (Control control in MainForm.Controls)
        {
            if (control is UserControl)
            {
                if (control.Name == "MyUserControlName")
                {
                    tmp = control as UserControl;
                }
            }
        }
