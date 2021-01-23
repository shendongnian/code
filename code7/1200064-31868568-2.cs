    [HttpPost]
    public ActionResult SelectResidence(StudentPortalModel model)
    {
      if (!ModelState.IsValid)
      {
        // repopulate locations and return view
      }
      return RedirectToAction("SelectResidence", new { locationID = model.ChosenLocation });
    }
