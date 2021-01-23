     usrctrl_camera_control = new usrctrl_Camera_Control();
     Binding b = new Binding("IsNyetEnabled");
     b.Source = this;
     b.Mode = BindingMode.OneWay;
     usrctrl_camera_control.SetBinding(usrctrl_Camera_Control.IsButtonEnabledProperty, b);
