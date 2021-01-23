    var theEnteredAdress = adressEntry.Text;
    Geocoder gc = new Geocoder();
    IEnumerable<Position> result =
        await gc.GetPositionsForAddressAsync(theEnteredAdress);
    foreach (Position pos in result)
    {
        System.Diagnostics.Debug.WriteLine("Lat: {0}, Lng: {1}", pos.Latitude, pos.Longitude);
    }
