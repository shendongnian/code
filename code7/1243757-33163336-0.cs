    public ActionResult Initialize(int Id)
    {
      SessionProvider.IntializeMethod  = true;
      // remaining code
      return Json(new { Id = 1, Name = "Sachin" }, JsonRequestBehavior.AllowGet);   ////I changed here ////
      //return Json(Id, JsonRequestBehavior.AllowGet);
    }
