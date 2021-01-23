    var Control = new TrackBar();
    Control.MouseWheel += new MouseEventHandler(delegate(object sender, MouseEventArgs e)
    {
        ((HandledMouseEventArgs)e).Handled = true;
    });
