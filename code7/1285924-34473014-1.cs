    // in your view model class
    public double DrivingDistanceInMiles
    {
        get
        {
            return new MapService().GetDrivingDistanceInMiles(this.Origin, this.Destination);
        }
    }
