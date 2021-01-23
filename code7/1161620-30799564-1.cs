        string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(ipAddress))
        {
            ipAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        string APIKey = "<Your API Key>";
        string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            Location location = new JavaScriptSerializer().Deserialize<Location>(json);
            List<Location> locations = new List<Location>();
            locations.Add(location);
            gvLocation.DataSource = locations;
            gvLocation.DataBind();
        }
    
    public string IPAddress { get; set; }
    public string CountryName { get; set; }
    public string CountryCode { get; set; }
    public string CityName { get; set; }
    public string RegionName { get; set; }
    public string ZipCode { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string TimeZone { get; set; }
