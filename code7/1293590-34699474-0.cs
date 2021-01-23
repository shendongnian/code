    async void OnButtonClicked(Object sender, EventArgs args)
    {
    
        Image image = (Image) sender;
    
        // pass the value of the StyleId string to the detail page
        Navigation.PushAsync (new PictureDetailPage (image.StyleId));
    
    }
