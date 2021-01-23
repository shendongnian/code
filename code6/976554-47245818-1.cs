    [HttpGet]
    public ActionResult DeleteFacilitator( Int64 FacID)
    {
      if(FacID == null)
      {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var Resul= db.NFE_Facilitator.Find(ID);
      if(Resul==null)
      {
          return HttpNotFound();
      }
          return View(Resul);
    }
    [HttpPost,ActionName("DeleteFacilitator")]
    public ActionResult DeleteConfirmed( Int64 ID)
    {
       var Resul= db.NFE_Facilitator.Find(ID);
       db.NFE_Facilitator.Remove(Resul);
       db.SaveChanges();
       return RedirectToAction("SearchFacilitator");
    }
