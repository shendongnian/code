    var client = _db.Clients.SingleOrDefault(c=> c.Id = "Bob Row Id")
    //Bob buy a car:
    client.Cars.Add(new Car()...)
    //change tire 1
    var car = client.Cars.SingleOrDefault(c=> c.Id = "Car Row Id")
    car.TireStatus.Tire1 = "New"
    ....
    
    //Persist all changes
    //Existing objects will be updated and the new ones created in this process will be inserted
    _db.SaveChanges()
