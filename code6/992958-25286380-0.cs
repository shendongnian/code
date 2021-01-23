    private void ConfSalvar(object sender, RoutedEventArgs e)
    {
        using(IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings)
        {
            if (iso.Contains("isoServer"))
            {
                iso["isoServer"] = server.Text;
            }
            else
            {
                iso.Add("isoServer", server.Text);
            }
        }
    }
