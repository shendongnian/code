    var locator = CrossGeolocator.Current;
    locator.DesiredAccuracy = 50;
    var position = await locator.GetPositionAsync (timeoutMilliseconds: 10000);
    Console.WriteLine ("Position Status: {0}", position.Timestamp);
    Console.WriteLine ("Position Latitude: {0}", position.Latitude);
    Console.WriteLine ("Position Longitude: {0}", position.Longitude);
