    [HttpGet]
    public JsonResult GetHospitals()
    {
        var hospitals = hospitalService.GetAllHospitals();
   
        // Replaces the apostrophes from the hospital name
        foreach(var hospital in hospitals) {
            hospital.Name = hospital.Name.Replace("'", ""); 
        }
        return Json(hospitals, JsonRequestBehavior.AllowGet);
    }
