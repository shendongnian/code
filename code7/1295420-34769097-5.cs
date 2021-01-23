    public IAsyncOperation<Geoposition> GetPositionAsync2()
            {
    
                return Task.Run<Geoposition>(async () => {
                    Geolocator g = new Geolocator();
                    var pos =  await g.GetGeopositionAsync();
                   
                    // Do something with pos here..
    
                    return pos;
                }).AsAsyncOperation();
