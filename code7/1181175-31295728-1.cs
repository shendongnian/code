     public string GetZipCodeBasedonCoordinates()
    {
        string zip = "";
        string url2 = @"https://maps.googleapis.com/maps/api/geocode/json?latlng=37.423021, -122.083739&sensor=false";
        System.Net.WebClient web = new System.Net.WebClient();
        var result = web.DownloadString(url2);
        RootObject root = JsonConvert.DeserializeObject<RootObject>(result);
        var allresults = root.results;
        foreach (var res in allresults)
        {
            foreach (var add in res.address_components)
            {
                var type = add.types;
                if (type[0] == "postal_code")
                {
                    zip = add.long_name;
                }
            }
        }
        return zip;
    }
