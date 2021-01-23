    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        try{
        
        RootObject myWeather =
            await OpenWeatherMapProxy.GetWeather(20.0,30.0);
        
        string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.weather[0].icon);
        ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
        ResultTextBlock.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " - " + myWeather.weather[0].description;
        
        }
        catch(Exception ex)
        {
           Debug.WriteLine(ex.Message);
           Debug.WriteLine(ex.StackTrace);
        }
    }
