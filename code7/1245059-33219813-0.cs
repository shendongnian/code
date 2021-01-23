    internal class NAVTEQEUDataSource : INAVTEQEUDataSource
    {
    	public async Task<IList<Geopoint>> SearchNearBy(double latitude, double longitude, double radius, int entityTypeId, int maxResult, string bingMapKey)
    	{
    		const string spatialBaseUrl = "http://spatial.virtualearth.net/REST/v1/data/";
    		string url =
    			"c2ae584bbccc4916a0acf75d1e6947b4/NavteqEU/NavteqPOIs?spatialFilter=nearby({0},{1},{2})&$filter=EntityTypeID%20eq%20'{3}'&$select=EntityID,DisplayName,Latitude,Longitude,__Distance&$top={4}&key={5}";
    		HttpClient httpClient = new HttpClient { BaseAddress = new Uri(spatialBaseUrl) };
    		url = string.Format(url, latitude, longitude, radius, entityTypeId, maxResult, bingMapKey);
    		string response = await httpClient.GetStringAsync(url);
    		XmlUtil xmlUtil = new XmlUtil(response);
    		IList<XElement> properties = xmlUtil.GetElements("entry").ToList();
    		IList<Geopoint> result = new List<Geopoint>();
    		foreach (var property in properties)
    		{
    			BasicGeoposition basicGeoposition = new BasicGeoposition();
    
    			double temp;
    			if (double.TryParse(xmlUtil.GetRelativeElement(property, "content.properties.Latitude").Value, out temp))
    				basicGeoposition.Latitude = temp;
    			if (double.TryParse(xmlUtil.GetRelativeElement(property, "content.properties.Longitude").Value, out temp))
    				basicGeoposition.Longitude = temp;
    			result.Add(new Geopoint(basicGeoposition));
    		}
    
    		return result;
    	}
    }
