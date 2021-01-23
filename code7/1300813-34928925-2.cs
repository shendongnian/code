    Control = new TrackBar();
    Control.MouseWheel += Control_MouseWheel;
    private void Control_MouseWheel(object sender, MouseEventArgs e)
    {
         ((HandledMouseEventArgs)e).Handled = true;
    }
