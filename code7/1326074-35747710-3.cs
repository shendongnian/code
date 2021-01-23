	var result = (from c in dc.GetTable<tblCompany>()
				  let r = (from re in dc.GetTable<tblRating>()
						   where re.CompanyId == c.Id && re.Rate != null
						   select re.Rate)
				  let i = (from im in dc.GetTable<tblImages>()
						   where im.CompanyId == c.Id
						   select im.ImagePath)
				  select new SearchResult
				  {
					  CompanyName = c.Name,
					  Location = c.Location,
					  AverageRate = r.Average(),
					  ImagePath = i.ToList()
				  }).ToList<Company>();
