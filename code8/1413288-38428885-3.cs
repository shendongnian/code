    public ActionResult Create()
    {
        var model = new PatientAdmissionViewModel()
        {
            WardList = new SelectList(db.Wards, "WardID", "WardNumber"),
            DoctorList = new SelectList(db.Doctors, "DoctorID")
        };
        return View(model);
    }
