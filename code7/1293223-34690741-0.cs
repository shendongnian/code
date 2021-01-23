     [Activity(Label = "Location Activity", MainLauncher = false, Icon = "@drawable/icon")]
     public class GetLoationActivity : BaseActivity, Android.Locations.ILocationListener
        {
            Location userLocation;
            Button getLocationButton = FindViewById<Button>(Resource.Id.getLocationButton);
            getLocationButton.LongClick += (e, d) =>
                {
                    //TODO:Show Progress Dialog 
                    var _LocationManager = LocationContext.GetSystemService(Context.LocationService) as LocationManager;
                    var LocationChangedCalled = false;
                    var PublishAwayFenceThread = new Thread(new ThreadStart(delegate
                        {
                            StartLocationChangeListener(this);
                        }
                        }));
                    PublishAwayFenceThread.Start();
                };
    
        }
    
        public void StartLocationChangeListener(Activity activity)
        {
            try
            {
                var locationCriteria = new Criteria();
                locationCriteria.Accuracy = Accuracy.Coarse;
                locationCriteria.PowerRequirement = Power.Medium;
                string locationProvider = Helper.Instance._LocationManager.GetBestProvider(locationCriteria, true);
                if (!String.IsNullOrEmpty(locationProvider))
                if (activity!= null)
                {
                    activity.RunOnUiThread(() =>
                        {
                            var _LocationManager = LocationContext.GetSystemService(Context.LocationService) as LocationManager;
                            _LocationManager.RequestLocationUpdates(locationProvider, 1000, 1, this);
                            Console.WriteLine("****---------*****Location Listener Started****---------*****");
                        });
                }
            }
            catch (Exception e)
            {
    
            }
        }
    
        public void OnLocationChanged(Location location)
        {
            try
            {
                userLocation = location;
                //TODO:Hide Loader
                StopLocationChangeListener();
                Console.WriteLine("****---------*****Location changed fired****---------*****");
                Console.WriteLine("****---------*****" + location.Latitude + "," + location.Longitude + "****---------*****");
            }
            catch (Exception e)
            {
    
            }
        }
    
        public void StopLocationChangeListener()
        {
            try
            {
                Activity _LocationContextAcitivity = (Activity)Helper.Instance.LocationContext;
                _LocationContextAcitivity.RunOnUiThread(() =>
                    {
                        var _LocationManager = LocationContext.GetSystemService(Context.LocationService) as LocationManager;
                        _LocationManager.RemoveUpdates(this);
                        Console.WriteLine("****---------*****Location Listener stopped****---------*****");
                    });
            }
            catch (Exception e)
            {
            }
        }
