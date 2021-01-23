    private void HubSectionTapped(object sender, TappedRoutedEventArgs e)
    {
        var hubSectiona = sender as HubSection;
        var name = hubSectiona.Name;
        NaviagteMethod(name);
    }
    
    public void NaviagteMethod(string name)
    {
        switch (name)
        {
            case "China":
                Frame.Navigate(typeof(SubtopicPage));
                break;
    
            case "Japan":
                Frame.Navigate(typeof(SubtopicPage));
                break;
        }
    }
