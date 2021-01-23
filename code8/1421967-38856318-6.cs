    class MapEntry
    {
    	public string Description { get; set; }
    	public string Name { get; set; }
    	public string Label { get; set; }
    	public IEnumerable<LatLng> InnerCoordinates { get; set; }
    	public IEnumerable<LatLng> OuterCoordinates { get; set; }
    }
