    [HttpPost]
    public ActionResult MyController(AcademicViewModel model) // should be named Create?
    {
      var userID = ....
      AcademicMaster graduation = new AcademicMaster
      {
        Type = AcademicType.Graduation,
        Qualification = model.GraduationAchievement,
        Achievement = model.GraduationAchievement,
        UserId = userID;
      };
      db.AcademicMasters.Add(graduation);
      // Repeat for PostGraduation and Professional
      db.SaveChanges();
      // redirect?
    }
    
