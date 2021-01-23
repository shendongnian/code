    if (ApiInformation.IsApiContractPresent ("Windows.Phone.PhoneContract", 1, 0)) {  
        Windows.Phone.UI.Input.HardwareButtons.BackPressed += (s, a) =>
        {
            Debug.WriteLine("BackPressed");
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                a.Handled = true;
            }
        };
    }
