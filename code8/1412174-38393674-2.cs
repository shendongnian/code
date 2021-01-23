    private async void NavigateButton_OnClicked(object o, EventArgs e)
    {  
        var yourClass = new YourClass {
          Slider1Text = MainLabel1.Text,
          Slider2Text = MainLabel2.Text
        };
        await Navigation.PushAsync (new Page1(yourClass));
    }
