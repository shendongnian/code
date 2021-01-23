    result = (from a in dc.GetTable<tblCompany>()
                          join b in dc.GetTable<tblRating>()
                          on a.Id equals b.CompanyId
                          join c in dc.GetTable<tblImages>()
                          on a.Id equals c.CompanyId
                          group new { b.Rate, c.ImagePath}
                          by new { a.Id, a.Location,a.Name} into groupList
                          select new Company
                          {
                              CompanyName = groupList.Key.Name,
                              Location = groupList.Key.Location,
                              AverageRate = groupList.Average(a=>a.Rate),
                              ImagePath = groupList.Select(i=>i.ImagePath).ToList()
                          }).ToList<Company>();
