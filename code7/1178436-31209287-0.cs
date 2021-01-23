    using GoogleMapsApi;
    using GoogleMapsApi.Entities.Directions.Request;
    var request = new DirectionsRequest
    {
          Origin = employeeAdress,
          Destination = companyAdress,
          TravelMode = TravelMode.Transit,
          Alternatives = true,
          ApiKey = key,
          DepartureTime = DateTime.Now
    };
    var routes = GoogleMaps.Directions.Query(request);
