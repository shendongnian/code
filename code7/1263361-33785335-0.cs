    var groupedData = context.s84_Schedule.AsExpandable()
                                  .Where(predicate)
                                  .GroupBy(c => new { c.CustomerID,     c.s84_Customer.CustomerName, c.SubdivisionID, c.s84_Subdivision.SubdivisionName, c.LotNumber })
                                  .Select(grouped => new s84_Report_Project_POCO
                                  {
                                      CustomerID = grouped.Key.CustomerID,
                                      CustomerName = grouped.Key.CustomerName,
                                      SubdivisionID = grouped.Key.SubdivisionID,
                                      SubdivisionName = grouped.Key.SubdivisionName,
                                      LotNumber = grouped.Key.LotNumber,
                                      Products = grouped
                                        .Select(x => new s84_Report_Project_Product
                                      {
                                          ProductID = x.ProductID,
                                          ProductName = x.s84_Product.ProductName,
                                          ProductDate = x.CustomerExpectedDate,
                                          FieldRepID = x.FieldRepID,
                                          FieldRepName = x.s84_FieldRep.FieldRepName,
                                          InstallerID = x.InstallerID,
                                          InstallerName = x.s84_Installer.InstallerName,
                                          StatusID = x.StatusID,
                                          StatusColor = x.s84_Status.StatusColor,
                                          StatusName = x.s84_Status.StatusName,
                                          Completed = x.Completed
                                      }).OrderBy(x => x.CustomerExpectedDate).ToList()
                                  });
