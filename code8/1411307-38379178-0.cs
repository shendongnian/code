    public override async void OnAppearing()
    {
       base.OnAppearing();
    
       // Show your overlay
       overlay.IsVisible = true;
       Clublistview.IsVisible = false;
       
       // Load the items into the ItemsSource
       await setClubs(Clublistview);
    
       // Hide the overlay
       overlay.IsVisible = false;
       Clublistview.IsVisible = true;
    }
