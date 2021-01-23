    private void ComboBox_DropDownClosed(object sender, EventArgs e)
    {
        Point m = Mouse.GetPosition(this);
        VisualTreeHelper.HitTest(this, this.FilterCallback, this.ResultCallback, new PointHitTestParameters(m));
    }
    private HitTestFilterBehavior FilterCallback(DependencyObject o)
    {
        var c = o as Control;
        if ((c != null) && !(o is MainWindow))
        {
            if (c.Focusable)
            {
                if (c is ComboBox)
                {
                    (c as ComboBox).IsDropDownOpen = true;
                }
                else
                {
                    var mouseDevice = Mouse.PrimaryDevice;
                    var mouseButtonEventArgs = new MouseButtonEventArgs(mouseDevice, 0, MouseButton.Left)
                    {
                        RoutedEvent = Mouse.MouseDownEvent,
                        Source = c
                    };
                    c.RaiseEvent(mouseButtonEventArgs);
                }
                return HitTestFilterBehavior.Stop;
            }
        }
        return HitTestFilterBehavior.Continue;
    }
    private HitTestResultBehavior ResultCallback(HitTestResult r)
    {
        return HitTestResultBehavior.Continue;
    }
