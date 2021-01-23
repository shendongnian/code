    var heightTable = (from p in db.Products
                       where p.CatProducts.Any(cp => cp.CatID == catID)
                          && p.Enabled && (p.CaseOnly == null || !p.CaseOnly)
                       select new 
                              {
                                  Height = p.Height, 
                                  sort = Convert.ToDecimal(p.Height.Replace("\"", ""))
                              }).OrderBy(s => s.sort);
