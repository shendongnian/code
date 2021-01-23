    if(Device.OS == TargetPlatform.Android)
                    customMap.MoveToRegion (MapSpan.FromCenterAndRadius (customMap.CustomPins [0].Pin.Position, Distance.FromMiles (55.0)));
                    if (Device.OS == TargetPlatform.iOS) {
                        Device.StartTimer (TimeSpan.FromMilliseconds (500), () => {
                            customMap.MoveToRegion (MapSpan.FromCenterAndRadius (customMap.CustomPins [0].Pin.Position, Distance.FromMiles (55.0)));
                            return false;
                        });
                    }
                }
