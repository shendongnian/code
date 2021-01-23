    if (!success )
    {
        toggleSwitch.Toggled -= ToggleSwitch_Toggled;
        try
        {
          toggleSwitch.IsOn = !toggleSwitch.IsOn;
        }
        finally
        {
          toggleSwitch.Toggled += ToggleSwitch_Toggled;
        }
    }
