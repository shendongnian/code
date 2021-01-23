    void onButtonClicked1 (object sender, EventArgs e)
    {
        Pin pin = (Pin)sender;
        pin.Address = myString;
        Navigation.PushAsync (new DetailPage (pin.Address));
    }
