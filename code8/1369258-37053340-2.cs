    var singleHospital = db.Hospitals
                           .Include(y=>y.UserHospitals)
                           .Where(x => x.UserHospitals.Any(u => u.Id == userID 
                                                             && u.HospitalID==hospitalId ))
                           .FirstOrDefault();
    if(singleHospital!=null)
    {
         //Safely use it.
    }
