    var hospitalId =5;
    var result = db.Hospitals
                   .Include(y=>y.UserHospitals)
                   .Where(x => x.UserHospitals.Any(u => u.Id == userID 
                                                     && u.HospitalID==hospitalId ))
                   .ToList();
