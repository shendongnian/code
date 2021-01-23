    public static void CreateGeofence(BasicGeoposition position, double radius, string id = "default")
            {
                // The Geofence is a circular area centered at (latitude, longitude) point, with the
                // radius in meter.
                var geocircle = new Geocircle(position, radius);
            // Sets the events that we want to handle: in this case, the entrace and the exit
            // from an area of intereset.
            var mask = MonitoredGeofenceStates.Entered | MonitoredGeofenceStates.Exited;
            // Specifies for how much time the user must have entered/exited the area before 
            // receiving the notification.
            var dwellTime = TimeSpan.FromSeconds(1);
            // Creates the Geofence and adds it to the GeofenceMonitor.
            var geofence = new Geofence(id, geocircle, mask, false, dwellTime);
            try
            {
                GeofenceMonitor.Current.Geofences.Add(geofence);
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e);
                // geofence already added to system
            }
        }
