    gpx myObject = deserialseGPXFile(); // example
    DataTable table = new DataTable();
    
    table.Columns.Add("lat", typeof(double));
    table.Columns.Add("lon", typeof(double)); 
    foreach (TrackPart tPart in myObject.TrackCollection)
    {
        table.Rows.Add(tPart.lattitude, tPart.longitude);
    }
