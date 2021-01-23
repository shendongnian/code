    parent.RegisterType<IVehicle, Car>("car");
    parent.RegisterType<IVehicle, Bus>("bus");
    // Notice the strings being used match the registrations
    var bus = parent.Resolve<IVehicle>("bus"); 
    var car = parent.Resolve<IVehicle>("car");
