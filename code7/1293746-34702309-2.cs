       private async void loadPushpin(object sender, RoutedEventArgs e)
    {
        using (var dbConn = new SQLiteConnection(App.DB_PATH))
        {
            var query = dbConn.Table<Contacts>();
            var result = query.ToList();
            foreach (var item in result)
            {
                 Contacts obj = new Contacts();
                 MapIcon1.Location = new Geopoint(new BasicGeoposition()
                 {
                     Latitude = Convert.ToDouble(item.Latitude),
                     Longitude = Convert.ToDouble(item.Longitude)
                 });
   
                var ims = new InMemoryRandomAccessStream();
                var bytes = Convert.FromBase64String(item.ImageString);//set your image base 64 string here...
                var dataWriter = new DataWriter(ims);
                dataWriter.WriteBytes(bytes);
                await dataWriter.StoreAsync();
                ims.Seek(0);
       
               MapIcon MapIcon1 = new MapIcon();
               MapIcon1.Image = RandomAccessStreamReference.CreateFromStream(ims);
                   MapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                   MapIcon1.Title = item.Name;
                 MyLocationMap.MapElements.Add(MapIcon1);
            }
        }
    }
