    // pull down the object
    var deal = newData.tVehicleLogs.Where(v => v.Id == SOMEID).FirstOrDefault();
    DateTime targetDate = new DateTime(2014,06,27);
    if (tVehicleLogs.DateChaned <= DateTime.Now 
        && tVehicleLogs.DateChaned >= targetDate) {
    }
