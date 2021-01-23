               //Get customers that starts with
                var qSW = from row in DataAccess.metadata.db_Customer
                          where row.accountID == accountID
                          && row.isActive                         
                          where (row.Name + " " + row.LastName).StartsWith(search)
                          || row.Company.StartsWith(search)
                          || row.reference.StartsWith(search)
                          select new bl_customerNames
                          {
                              customerID = row.customerID,
                              CustomerName = row.Name + " " + row.LastName,
                              Company = row.Company,
                              Reference = row.reference,
                              Email = row.Email,
                              CurrencyCode = row.CurrencyCode,
                              isSuspended = row.isSuspended
                             
                          };
                
                //Order
                qSW = qSW.OrderBy(r => r.CustomerName).ThenBy(r => r.Company).ThenBy(r => r.Reference);
                //Get customers that contains
                var qC = from row in DataAccess.metadata.db_Customer
                          where row.accountID == accountID
                          && row.isActive
                         
                          where (row.Name + " " + row.LastName).Contains(search)
                          || row.Company.Contains(search)
                          || row.reference.Contains(search)
                          select new bl_customerNames
                          {
                              customerID = row.customerID,
                              CustomerName = row.Name + " " + row.LastName,
                              Company = row.Company,
                              Reference = row.reference,
                              Email = row.Email,
                              CurrencyCode = row.CurrencyCode,
                              isSuspended = row.isSuspended                            
                          };
                //If search is less then 3 chars limit to 10 to help with performance
                if(search.Count() > 2)
                    qC = qC.OrderBy(r => r.CustomerName).ThenBy(r => r.Company).ThenBy(r => r.Reference);
                else
                    qC = qC.OrderBy(r => r.CustomerName).ThenBy(r => r.Company).ThenBy(r => r.Reference).Take(10);
                //Concat list leaving out duplicates
                var SList = qSW.Concat(qC);
               
                // Return List
                return SList.ToList();
