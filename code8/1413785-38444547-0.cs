    var  result = (from a in list1 
                   join b in list2 on a.Name equals b.Name 
                   select new Person()
                   {
                      Name = a.Name,
                      Address = a.Address
                      Country = b.Country ?? a.Country  
                      Continent = b.Continent ?? a.Continent 
                   }).ToList();
