    public static  IAsyncOperation <Geoposition> GetGeopoisitionAsync()
            {
                Geolocator g = new Geolocator();
                return g.GetGeopositionAsync() as IAsyncOperation<Geoposition> ;                        
            }
