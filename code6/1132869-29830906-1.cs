    var est = AgencyContext.Estate.Where(...).ToArray();
    var etype = AgencyContext.EstateType.Where(...).ToArray();
    // You might have to enter debug mode to determine the correct Table indicies
    estateCrystalReport1.Database.Tables[0].SetDataSource(est);
    estateCrystalReport1.Database.Tables[1].SetDataSource(etype);
