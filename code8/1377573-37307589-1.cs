    public class PropertyPositionInsert
    {
        public string PropertyId { get; set; }
        public string Xposition { get; set; }
        public string Yposition { get; set; }
    }
    public IHttpActionResult JsonResult (PropertyPositionInsert obj)
    {
     obj.PropertyId;
     obj.Xposition ;
     obj.Yposition; 
    }
