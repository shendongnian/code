    private void YourToggleSwitch_Toggled(object sender, RoutedEventArgs e){
        if (toggleSwitch.IsOn == true){
            Debug.WriteLine("On");
        }
        else{
            Debug.WriteLine("OFF");
        }
    }
