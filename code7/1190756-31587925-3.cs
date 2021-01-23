    var latestTests = db.PatientChecklists
            .Where(x => x.PatientMedicine.Patient.ClinicId == clinicID)
            .OrderBy(x => x.NextTest);
    
    if(all == "")
    {
        latestTests = latestTests.Take(10);
    }
