    foreach (DataRow dr in ds_Macrolist_C.Tables[0].Rows)
    {
        System.Windows.Controls.Primitives.ToggleButton btn3 = new System.Windows.Controls.Primitives.ToggleButton();
    
        btn3.Template = (ControlTemplate)System.Windows.Application.Current.FindResource("Template_8");
    
        p_zone.Children.Add(btn3);
    
        var states = VisualStateManager.GetVisualStateGroups(this);
    
        btn3.Loaded += Button_Loaded;
        btn3.Click += (s, ee) =>
        {
            if (btn3.IsChecked == true)
            {
                bool success2 = VisualStateManager.GoToState(btn3, "UnSelected", true);
    
                //rest of code
            }
        };
    
    }
    private void Button_Loaded(object sender, EventArgs e)
    {
        var button = sender as System.Windows.Controls.Primitives.ToggleButton;
        button.Loaded -= Button_Loaded;
        bool shouldReturnTrue = VisualStateManager.GoToState(button, "Selected", true);
    }
