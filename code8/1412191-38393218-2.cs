    IPlaces places = _contact.GetFacet<IPlaces>("name form XML config");
    IPlace newPlace = places.Places.Create();
    newPlace.Description = "test";
    ICoordinate newCoord = newPlace.Coordinate.Create();
    newCoord.Longitude = 0;
