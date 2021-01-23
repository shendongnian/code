    using Windows.Devices.Radios;
    
    public async Task<bool> IsWifiOn() 
    {
                    await Radio.RequestAccessAsync();
    
                    var radios = await Radio.GetRadiosAsync();
                    foreach (var radio in radios)
                    {
                        if (radio.Kind == RadioKind.WiFi)
                        {
                            return  radio.State == RadioState.On;
                        }
                    }
                    return false;
    }
