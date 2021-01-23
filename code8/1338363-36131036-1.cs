    public class SegmentViewModel
    {
        public string SegmentID { get; set; } //not sure if it of string type
        public string SegmentName { get; set; }
    }
    
    public IEnumerable<SegmentViewModel> FillSegment(int siteid)
    {
        using (DBConnection db = new DBConnection())
        {
            return db.Segment.Where(c => c.SiteID == siteid).Select(x => new SegmentViewModel
            {
                SegmentID = x.SegmentID,
                SegmentName = x.SegmentName
            });
        }
    }
    // you can also use JsonResult instead of ActionResult
    public JsonResult FillSegment(int siteid)
    {
        SegmentHelper segmenthelper = new SegmentHelper();      
        return Json(segmenthelper.FillSegment(siteid), JsonRequestBehavior.AllowGet);
    }
