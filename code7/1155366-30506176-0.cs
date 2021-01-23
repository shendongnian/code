      public ActionResult DashboardJson(int? id)
        {
            //get all widgets associated dashboard
            var getWidgetsQuery = (from widgets in db.widgets
                                   where widgets.DashID == id
                                   select widgets);
    
            var widgets = getWidgetsQuery;
    
            return Json(widgets, JsonRequestBehavior.AllowGet);
        }
