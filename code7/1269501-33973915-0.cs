    private async Task ToggleSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
    
            if(toggleSwitch == null || !toggleSwitch.IsOn)
              return;
            // You are missing your await statement....
            success = await dummyService.performAction(toggleSwitch.IsOn); 
            if (!success )
            {
                //raise dialog to inform user here
                toggleSwitch.IsOn = !toggleSwitch;
            }
        }
