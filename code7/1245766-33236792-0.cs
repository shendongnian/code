      public JsonResult EventList() {
          var results = db.Events.Select(e => new {
                              OrderID = e.EventID,
                              OrderTitle = e.EventType,
                              OrderDate = e.Title
            }).ToList();
    
        return new JsonResult(){Data = results, JsonRequestBehavior.AllowGet};
    }
