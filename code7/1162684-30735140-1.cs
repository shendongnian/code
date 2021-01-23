    protected override void OnNavigationFromPage(System.Windows.Navigation.NavigationEventArgs e)
    {
        if (e.Uri.ToString() != "app://external/") 
        {
            //App being suspended.
        }
        else
        { 
            UnSubscribeFromEvents(); 
        }
    }
