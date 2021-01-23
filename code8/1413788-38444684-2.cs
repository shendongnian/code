    var resulttt = (from a in list1
                    join b in list2 on a.Name equals b.Name
                    select new Person
                    {
                        Name = a.Name,
                        Address = a.Address ?? b.Address,
                        Country = a.Country ?? b.Country,
                        Continent = a.Continent ?? b.Continent
                    }).ToList();
