    public JsonResult GetEvents()
    {
        using (var db = new MyDatabaseEntities())
        {
            var select = from cevent in db.EventTables
                         select new {
                             id = cevent.Id,
                             start = cevent.Start_Time.AddSeconds(1).ToString("yyyy-MM-ddTHH:mm:ssZ"),
                             end = cevent.End_Time.ToString("yyyy-MM-ddTHH:mm:ssZ")
                         };
            var rows = select.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }            
    }
