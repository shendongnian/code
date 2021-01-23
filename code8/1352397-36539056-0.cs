    using System;
    using Android.App;
    using Android.Content;
    using Android.Locations;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using Java.Lang;
    using Java.Util;
    using Debug = System.Diagnostics.Debug;
    
    namespace App24_Droid
    {
        [Activity(Label = "App24_Droid", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity, GpsStatus.IListener, ILocationListener
        {
            int count = 1;
            private LocationManager locationManager = null;
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                // Get our button from the layout resource,
                // and attach an event to it
                Button button = FindViewById<Button>(Resource.Id.MyButton);
    
                locationManager = (LocationManager) GetSystemService(Context.LocationService);
                locationManager.AddGpsStatusListener(this);
                locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, this);
    
                GpsStatus gpsStatus = locationManager.GetGpsStatus(null);
                if (gpsStatus != null)
                {
                    IIterable satellites = gpsStatus.Satellites;
                    IIterator sat = satellites.Iterator();
                    string lSatellites = null;
                    int i = 0;
                    while (sat.HasNext)
                    {
                        GpsSatellite satellite = sat.Next().JavaCast<GpsSatellite>();
                        Debug.WriteLine(satellite.Prn);
                    }
                }
    
    
                button.Click += delegate
                {
                    button.Text = string.Format("{0} clicks!", count++);
                    
                };
            }
    
            public void OnGpsStatusChanged(GpsEvent e)
            {
                GpsStatus gpsStatus = locationManager.GetGpsStatus(null);
                if (gpsStatus != null)
                {
                    IIterable satellites = gpsStatus.Satellites;
                    IIterator sat = satellites.Iterator();
                    string lSatellites = null;
                    int i = 0;
                    while (sat.HasNext)
                    {
                        GpsSatellite satellite = sat.Next().JavaCast<GpsSatellite>();
                        Debug.WriteLine(satellite.Prn);
                    }
                }
            }
    
            public void OnLocationChanged(Location location)
            {
                
            }
    
            public void OnProviderDisabled(string provider)
            {
                
            }
    
            public void OnProviderEnabled(string provider)
            {
                
            }
    
            public void OnStatusChanged(string provider, Availability status, Bundle extras)
            {
                
            }
        }
    }
