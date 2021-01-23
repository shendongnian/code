       // Create an instance of the control
       var controlType = typeof(Control).Assembly.GetType(fullyQualifiedControl, true);
       var control = Activator.CreateInstance(controlType);
        
        switch (fullyQualifiedControl)
        {
           case "System.Windows.Controls.RadioButton":
              ((RadioButton)control).Checked += new RoutedEventHandler(DataDrivenControl_Checked);
              ((RadioButton)control).Unchecked += new RoutedEventHandler(DataDrivenControl_UnChecked);
              break;
        }
