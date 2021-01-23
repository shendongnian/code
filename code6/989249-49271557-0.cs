        public async void OnButtonClickHandler(Object sender, EventArgs e)
    {
        try
        {
            //ShowProgresBar("Loading...");
    
            await Task.Run(() =>
            {
                Task.Delay(2000); //wait for two milli seconds
    
                //TODO Your Business logic goes here
                //HideProgressBar();
    
            });
    
            await DisplayAlert("Title", "Delayed for two seconds", "Okay");
    
        }
        catch (Exception ex)
        {
    
        }
    }
