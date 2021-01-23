    order.StaffID = 5;
    db.Orders.Add(order);
    db.SaveChanges();
    
    //select hospital from database.
    Hospital hospital = db.Hospitals.First(h => h.Id = order.HospitalId);
    
    dynamic email = new Email("Example");
    email.To = hospital.Email; // this is where you set the email you are sending to. 
    email.Send();
