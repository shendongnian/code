    public Coordinates
    {
        public string Title { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Description { get; set; }
    }
    
    public ActionResult GetCoordinates(){
    
        // get your coordinates
        List<Coordinates> coordinates = GetCoordinatesFromDatabase();
    
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var objectAsJsonString = serializer.Serialize(coordinates );
    
        return Json(objectAsJsonString);
    }
