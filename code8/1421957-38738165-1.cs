    System.IO.StreamReader file = new System.IO.StreamReader(@"file.csv");
    string line = file.ReadLine(); //escape the first line
    while((line = file.ReadLine()) != null)
    {
        var xmlString = line.Split(",")[2]; // or 3
        using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
        {
            reader.ReadToFollowing("coordinate");
            string coordinate = reader.Value;
            PolylineOptions geometry = new PolylineOptions();
            var latLngs = coordinate.Split(" ");
            foreach (var latLng in latLngs)
            {
                double lat = 0;
                double lng = 0;
                var arr = latLng.Split(",");
                double.TryParse(arr[0], out lat);
                double.TryParse(arr[1], out lng);
                geometry.Add(new LatLng(lat, lng));
            }
            Polyline polyline = mMap.AddPolyline(geometry);
            // Do something with your polyline
        }
    }
    
    file.Close();
