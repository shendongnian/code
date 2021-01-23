    var entity = db.Set<Clinic>().Create();
    
    //mapping the values of your view models to data models
    entity.Name = clinic.Name;
    entity.Description = clinic.Descrption;	
    
    //add 
    db.clinics.Add(entity);
    db.SaveChanges();
    
    return Ok(entity.clinicID);
