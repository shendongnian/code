    public ActionResult CheckID(int projectID, int phraseID) {
      ViewBag.projectID= projectID;
      ViewBag.phraseID= phraseID;
      if (...check my projectID is valid...) {
        ... return to your project view ...
      } else {
        ... return to your phrase view ...
      }
    }
