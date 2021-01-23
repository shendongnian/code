    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class LocationServiceExt
    {
        private LocationService realLocation;
    
        private bool useMockLocation = false;
        private LocationInfoExt mockedLastData;
        private LocationServiceStatusExt mockedStatus;
        private bool mIsEnabledByUser = false;
    
        public LocationServiceExt(bool mockLocation = false)
        {
            this.useMockLocation = mockLocation;
    
            if (mockLocation)
            {
                mIsEnabledByUser = true;
                mockedLastData = getMockLocation();
            }
            else
            {
                realLocation = new LocationService();
            }
        }
    
        public bool isEnabledByUser
        {
            //realLocation.isEnabledByUser seems to be failing on Android. Input.location.isEnabledByUser is the fix
            get { return useMockLocation ? mIsEnabledByUser : Input.location.isEnabledByUser; }
            set { mIsEnabledByUser = value; }
        }
    
    
        public LocationInfoExt lastData
        {
            get { return useMockLocation ? mockedLastData : getRealLocation(); }
            set { mockedLastData = value; }
        }
    
        public LocationServiceStatusExt status
        {
            get { return useMockLocation ? mockedStatus : getRealStatus(); }
            set { mockedStatus = value; }
        }
    
        public void Start()
        {
            if (useMockLocation)
            {
                mockedStatus = LocationServiceStatusExt.Running;
            }
            else
            {
                realLocation.Start();
            }
        }
    
        public void Start(float desiredAccuracyInMeters)
        {
            if (useMockLocation)
            {
                mockedStatus = LocationServiceStatusExt.Running;
            }
            else
            {
                realLocation.Start(desiredAccuracyInMeters);
            }
        }
    
        public void Start(float desiredAccuracyInMeters, float updateDistanceInMeters)
        {
            if (useMockLocation)
            {
                mockedStatus = LocationServiceStatusExt.Running;
            }
            else
            {
                realLocation.Start(desiredAccuracyInMeters, updateDistanceInMeters);
            }
        }
    
        public void Stop()
        {
            if (useMockLocation)
            {
                mockedStatus = LocationServiceStatusExt.Stopped;
            }
            else
            {
                realLocation.Stop();
            }
        }
    
        //Predefined Location. You always override this by overriding lastData from another class 
        private LocationInfoExt getMockLocation()
        {
            LocationInfoExt location = new LocationInfoExt();
            location.latitude = 59.000f;
            location.longitude = 18.000f;
            location.altitude = 0.0f;
            location.horizontalAccuracy = 5.0f;
            location.verticalAccuracy = 5.0f;
            location.timestamp = 0f;
            return location;
        }
    
        private LocationInfoExt getRealLocation()
        {
            if (realLocation == null)
                return new LocationInfoExt();
    
            LocationInfo realLoc = realLocation.lastData;
            LocationInfoExt location = new LocationInfoExt();
            location.latitude = realLoc.latitude;
            location.longitude = realLoc.longitude;
            location.altitude = realLoc.altitude;
            location.horizontalAccuracy = realLoc.horizontalAccuracy;
            location.verticalAccuracy = realLoc.verticalAccuracy;
            location.timestamp = realLoc.timestamp;
            return location;
        }
    
        private LocationServiceStatusExt getRealStatus()
        {
            LocationServiceStatus realStatus = realLocation.status;
            LocationServiceStatusExt stats = LocationServiceStatusExt.Stopped;
    
            if (realStatus == LocationServiceStatus.Stopped)
                stats = LocationServiceStatusExt.Stopped;
    
            if (realStatus == LocationServiceStatus.Initializing)
                stats = LocationServiceStatusExt.Initializing;
    
            if (realStatus == LocationServiceStatus.Running)
                stats = LocationServiceStatusExt.Running;
    
            if (realStatus == LocationServiceStatus.Failed)
                stats = LocationServiceStatusExt.Failed;
    
            return stats;
        }
    }
    
    public struct LocationInfoExt
    {
        public float altitude { get; set; }
        public float horizontalAccuracy { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public double timestamp { get; set; }
        public float verticalAccuracy { get; set; }
    }
    
    public enum LocationServiceStatusExt
    {
        Stopped = 0,
        Initializing = 1,
        Running = 2,
        Failed = 3,
    }
