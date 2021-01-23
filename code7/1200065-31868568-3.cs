    public ActionResult SelectResidence(int locationID)
    {
      List<Residence> residences = (from data in db.Residences select data).Where(i => i.LocationId == locationID).ToList();
      StudentPortalModel model = new StudentPortalModel()
      {
        ChosenLocation = locationID,
        ResidenceListModel = new SelectList(residences, "ResidenceId", "BlockNumber")
      }
      return View(model);
    }
