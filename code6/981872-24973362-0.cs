        public Task<string> setLocationName()
        {
            var reverseGeocode = new ReverseGeocodeQuery();
            reverseGeocode.GeoCoordinate = new System.Device.Location.GeoCoordinate(this._currentLocationLatitude, this._currentLocationLongitude );
            var tcs = new TaskCompletionSource<string>();
            EventHandler<QueryCompletedEventArgs<System.Collections.Generic.IList<MapLocation>>> handler = null;
            handler = (sender, args) =>
            {
                    MapLocation mapLocation = args.Result.FirstOrDefault();
                    string l;
                    if (!mapLocation.Information.Address.District.Equals(""))
                        l = mapLocation.Information.Address.District;
                    else
                        l = mapLocation.Information.Address.City;
                    try
                    {
                        System.DateTime t = System.DateTime.UtcNow.AddHours(1.0);
                        if (t.Minute < 10)
                            IsolatedStorageSettings.ApplicationSettings["LiveTileLocation"] = l + " " + t.Hour + ":0" + t.Minute;
                        else
                            IsolatedStorageSettings.ApplicationSettings["LiveTileLocation"] = l + " " + t.Hour + ":" + t.Minute;
                        IsolatedStorageSettings.ApplicationSettings.Save();
                        this._currentLocationName = IsolatedStorageSettings.ApplicationSettings["LiveTileLocation"].ToString();
                    }
                    catch (Exception ee)
                    {
                        //Console.WriteLine(ee);
                    }
                    reverseGeocode.QueryCompleted -= handler;
                    tcs.SetResult(l);
            };
            reverseGeocode.QueryCompleted += handler;
            reverseGeocode.QueryAsync();
            return tcs.Task;
        }
