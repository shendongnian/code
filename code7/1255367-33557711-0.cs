    public class LocationManager : ILocationManager
    {
        public async Task<bool> IsGeolocationEnabledAsync()
        {
            bool result;
            Console.WriteLine (String.Format("Avaible on device: {0}", CLLocationManager.LocationServicesEnabled));
            Console.WriteLine (String.Format("Permission on device: {0}", CLLocationManager.Status));
    
            if (!CLLocationManager.LocationServicesEnabled) {
                result = false;
            } else if (CLLocationManager.Status == CLAuthorizationStatus.Denied || CLLocationManager.Status == CLAuthorizationStatus.Restricted) {
                result = false;
            } else if (CLLocationManager.Status == CLAuthorizationStatus.NotDetermined) {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
    
                Console.WriteLine ("Waiting for authorisation");
    
                CLLocationManager manager = new CLLocationManager ();
    
                manager.AuthorizationChanged += (object sender, CLAuthorizationChangedEventArgs args) => {
    
                    Console.WriteLine ("Authorization changed to: {0}", args.Status);
    
                    if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
                        tcs.SetResult (args.Status == CLAuthorizationStatus.AuthorizedAlways || args.Status == CLAuthorizationStatus.AuthorizedWhenInUse);
                    } else {
                        tcs.SetResult (args.Status == CLAuthorizationStatus.Authorized);
                    }
                };
    
                manager.Failed += (object sender, Foundation.NSErrorEventArgs e) => {
    
                    Console.WriteLine ("Authorization failed");
    
                    tcs.SetResult (false);
                };
    
                if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
                    manager.RequestWhenInUseAuthorization ();
                    result = await tcs.Task;
                } else {
                    result = false;
                }
    
                Console.WriteLine (String.Format ("Auth complete: {0}", tcs.Task.Result));
    
            } else {
                if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
                    result = CLLocationManager.Status == CLAuthorizationStatus.AuthorizedAlways || CLLocationManager.Status == CLAuthorizationStatus.AuthorizedWhenInUse;
                } else {
                    result = CLLocationManager.Status == CLAuthorizationStatus.Authorized;
                }
            }
    
            return result;
        }
    }
