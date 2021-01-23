    var vehiclesGrp = (from v in inVehicles.AsParallel().AsQueryable()
                      orderby v.TransactionDate descending 
                         group v by new
                                    {
                                     v.CCName,
                                     v.SwdsStoreCc,
                                     v.DADDivision,
                                     v.DADArea,
                                     v.DADDistrict,
                                     v.DADCity,
                                     v.Vin,
                                     v.CostCenter,                                     
                                     v.GLDivision,
                                     v.VehicleMake,
                                     v.FuelTankCapacity,
                                     v.FuelType,
                                     v.EplanNumber,
                                     v.LicensePlate,
                                     v.DateInService,
                                     v.EstimatedMpg,                                    
                                     v.VehicleStatus,                                      
                                    }
                          into gp
                          let uniqueVinAnyDriver = gp.Max(v => v.DriverLastName)
                          select new VehicleDetail
