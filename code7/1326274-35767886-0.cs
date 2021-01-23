    using (CarteringServiceClientDataContext dc = new CarteringServiceClientDataContext())
                    {  
                        result = (from a in dc.GetTable<tblSupplier>()
                                  join b in dc.GetTable<tblCity>()
                                  on a.CityId equals b.Id
                                  join c in dc.GetTable<tblZone>()
                                  on b.ZoneId equals c.Id
        
                                  let r = (from re in dc.GetTable<tblClientReview>()
                                           where re.SupplierId == a.Id
                                           select re.note).Average()
        
                                  let i = (from im in dc.GetTable<tblSupplierItem>()
                                           where im.SupplierId == a.Id
                                           select im.tblItem.IconPath).ToArray().Add("test")
        
                                  select new SearchResult
                                  {
                                      CompanyId = a.Id,
                                      CompanyName = a.Company,
                                      Localisation = a.Locality,
                                      City = b.Name,
                                      Zone = c.Name,
                                      Rating = r.ToString(),
                                      PathIcon1 = i.Take(1).SingleOrDefault(),
                                      PathIcon2 = i.Skip(1).Take(1).SingleOrDefault(),
                                      PathIcon3 = i.Skip(2).Take(1).SingleOrDefault(),
                                      PathIcon4 = i.Skip(3).Take(1).SingleOrDefault(),
                                      PathIcon5 = i.Skip(4).Take(1).SingleOrDefault()
                                  }).ToList<SearchResult>();
              }
