    public object Convert(object value, Type targetType, object parameter, string language)
    {
        Event _event = (Event) value;
        BasicGeoposition position = new BasicGeoposition();
        position.Latitude = _event.Latitude;
        position.Longitude = _event.Longitude;
        return new Geopoint(position);
    }
