    public class CoordsItemModel
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int altitude { get; set; }
        public int accuracy { get; set; }
        public int altitudeAccuracy { get; set; }
        public int heading { get; set; }
        public int speed { get; set; }
    }
    public class CoordsModel
    {
        public CoordsItemModel coords { get; set; }
        public long timestamp { get; set; }
    }
    [System.Web.Http.HttpPost]
    [Route("")]
    public IHttpActionResult Post(CoordsModel model)
    {
        DBEntities db = new DBEntities();
        db.spUpdateLocation(User.Identity.Name, model.coords.latitude.ToString(), model.coords.longitude.ToString());
        db.SaveChanges();
        return Ok(model.coords.latitude.ToString()); //return trash data for now
    }
