    public ActionResult EditInformation(int? id /*this will be passed from your route values in your view*/)
    {
        State myState = db.States.Find(id)
        
        ViewBag.State = new SelectList(ndb.States, "StateId", "StateName", myState.StateId);
    }//I only added this because this is what the question pertains to.
