    if (!success )
    {
        toggleSwitch.Toggled -= yourToggledEvent;
        try
        {
          toggleSwitch.IsOn = !toggleSwitch.IsOn;
        }
        finally
        {
          toggleSwitch.Toggled += yourToggledEvent;
        }
    }
