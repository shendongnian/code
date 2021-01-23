    private void Web_ScriptNotify(object sender, NotifyEventArgs e)
    {
        if (e.Value == "Collapsed")
        {
            MyEllipse.Visibility = Visibility.Collapsed;
        }
        else
        {
            MyEllipse.Visibility = Visibility.Visible;
        }
    }
