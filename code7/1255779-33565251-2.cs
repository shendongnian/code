    public JsonResult Edit(int? id)
    {
       if(id==null)
       {
          return Json(new { success = false, message = "Bad Request" }, JsonRequestBehavior.AllowGet);
       }
    
       car carTmp = db.car.Find(id);
       if (carTmp == null)
       {
          return Json(new { success = false, message = "Not Found" }, JsonRequestBehavior.AllowGet);
       }
    
       return Json(new { success = true, data = carTmp }, JsonRequestBehavior.AllowGet);
    }
