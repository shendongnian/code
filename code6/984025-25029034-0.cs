    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Color accentColour = (Color)Application.Current.Resources["PhoneAccentColor"];
        ContentPanel.Background = new SolidColorBrush(accentColour);
    }
