    public App()
    {
        if (Registry.GetValue("HKEY_CURRENT_USER", "URL", "") == null)
        {        
            //OPEN FORM HERE FRMLOGINVIEW.XAML
            StartupUri = new Uri("View/frmLoginView.xaml", UriKind.Relative);
            ServerURL = Registry.GetValue("HKEY_CURRENT_USER", "URL", "").ToString();
        }
    }
