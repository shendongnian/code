    var providerContactInfo = from vc in db.VendorContacts
                              join ps in db.ContactServices on new { vc.ContactID, vc.VendorID } equals new { ps.ContactID, ps.VendorID } into ps_join
                              from ps in ps_join.DefaultIfEmpty()
                              join c in db.Contacts on vc.ContactID equals c.ContactID
                              join v in db.Vendors on vc.VendorID equals v.VendorID                                           
                              orderby vc.ContactID descending
                              group ps by new
                              {
                                  v.VendorName,
                                  c.FirstName,
                                  c.MiddleName,
                                  c.LastName,
                                  c.ContactID,
                                  v.VendorID
                              } into g
                              select new ProviderContactInfo()
                              {
                                  VendorName = g.Key.VendorName,
                                  FirstName = g.Key.FirstName,
                                  MiddleName = g.Key.MiddleName,
                                  LastName = g.Key.LastName,
                                  Services = (from e in g
                                              from o in db.ContactServices
                                              join cps in db.Contacts on o.ContactID equals cps.ContactID
                                              join vps in db.Vendors on o.VendorID equals vps.VendorID
                                              join s in db.Services on o.ServiceID equals s.ServiceID
                                              where e.ServiceID == o.ServiceID
                                              && o.ContactID == g.Key.ContactID
                                              && o.VendorID == g.Key.VendorID
                                              select s).ToList()
                              }
