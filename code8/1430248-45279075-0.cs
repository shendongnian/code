                            from driverObj in AAWSADBEntitiesContext.tbl_Driver
                                   .Where(driver => ((zemechaObj.DriverId == driver.DriverId) ))
                                     .DefaultIfEmpty()
                                //fromBranch
                            from fromBranch in AAWSADBEntitiesContext.tbl_CompanyRegistrationInformation
                                  .Where(fromB => ((zemechaObj.FromBranchId == fromB.CompanyId)))
                                  
                                //toBranch
                            from toBranch in AAWSADBEntitiesContext.tbl_CompanyRegistrationInformation
                                  .Where(toB => ((zemechaObj.ToBranchId == toB.CompanyId)))
                                    //vehicle
                                 from vehicleObj in AAWSADBEntitiesContext.tbl_Vehicle
                                    .Where(veh => ((zemechaObj.VehicleId == veh.VehicleId)))
                                      .DefaultIfEmpty()
                                     //assistant one
                            from DriverAssistantOneObj in AAWSADBEntitiesContext.tbl_DriverAssistant
                                   .Where(driverAssistOne => ((zemechaObj.DriverAssitantFirstID == driverAssistOne.DriverAssistantId)))
                                     .DefaultIfEmpty()
                                //assistant one
                            from DriverAssistantTwoObj in AAWSADBEntitiesContext.tbl_DriverAssistant
                                   .Where(driverAssistTwo=> ((zemechaObj.DriverAssitantSecondID == driverAssistTwo.DriverAssistantId)))
                                     .DefaultIfEmpty()
                                select new BranchResourceForZemechaEntities()
                                {
                                    ForwaredResourseID = zemechaObj.ForwaredResourseID,
                                    ServiceStartDate = zemechaObj.ServiceStartDate.ToString(),
                                    ServiceEndDate = zemechaObj.ServiceEndDate.ToString(),
                                    ForwaredDate = zemechaObj.ForwaredDate.ToString(),
                                    Status = zemechaObj.Status,
                                    Comment = zemechaObj.Comment,
                                    //from Branch
                                    FromBranchName = fromBranch.CompanyName,
                                    //To Branch
                                    ToBranchName = toBranch.CompanyName,
                                    VehicleId = zemechaObj.VehicleId,
                                    //Vehicle info
                                    PlateNumber = vehicleObj.PlateNumber+" ",
                                    DriverId = zemechaObj.DriverId,
                                    //Driver Full Name
                                    DriverFullName = driverObj.FirstName + " " + driverObj.MiddleName + " " + driverObj.LastName,
                                    // Driver Assitant one Full Name
                                    DriverAssitantFirstID = zemechaObj.DriverAssitantFirstID,
                                    DriverAssistantOneFullName = DriverAssistantOneObj.FirstName + " " + DriverAssistantOneObj.MiddleName + " " + DriverAssistantOneObj.LastName,
                                    // Driver Assitant Two Full Name
                                    DriverAssitantSecondID = zemechaObj.DriverAssitantSecondID,
                                    DriverAssistantTwoFullName = DriverAssistantTwoObj.FirstName + " " + DriverAssistantTwoObj.MiddleName + " " + DriverAssistantTwoObj.LastName,
                                    CompanyId = zemechaObj.CompanyId,
                                    FromBranchId = zemechaObj.FromBranchId,
                                    ToBranchId = zemechaObj.ToBranchId,
                                    BrLoggedUserId = zemechaObj.BrLoggedUserId.ToString()
                                }).ToList();
            return myresult.ToList<BranchResourceForZemechaEntities>();
