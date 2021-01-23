    [HttpPost]
    public JsonResult IsSessionAlive()
    { 
        if (Session.Contents.Count == 0)
        {
            return this.Json(new{ IsAlive = false}, JsonRequestBehavior.AllowGet)
        }
        return this.Json(new{ IsAlive = true}, JsonRequestBehavior.AllowGet)
    }
