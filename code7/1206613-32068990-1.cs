    public ActionResult Details(int? id)
    {
      ....
      personalDetails personalDetails = db.personalDetails.Find(id);
      ....
      SocialViewModels model = new SocialViewModels()
      {
        ID = personalDetails.personID,
        Rehber = personalDetails.rehber,
        MarriageStatus = personalDetails.personal.familyStatusID,
        ....
        MarriageStatusList = new SelectList(db.familyStatus, "ID", "familyStatusName"),
        ....
      };
      return View(model);
    }
