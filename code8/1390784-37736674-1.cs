    var groupedVehs = from vehvoila in DB.tblVeh
                      where vehvoila == "23065"
                         && vehvoila.Name != ""
                      group vehvoila by vehvoila.Name into g
                      select new
                      {
                          Name = g.Key,
                          Count = g.Count()
                      });
