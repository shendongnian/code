    var providerContactInfo = (from vc in db.VendorContacts
                               join ps in db.ContactServices on new { vc.ContactID, vc.VendorID } equals new { ps.ContactID, ps.VendorID } into ps_join
                               from ps in ps_join.DefaultIfEmpty()
                               join c in db.Contacts on vc.ContactID equals c.ContactID
                               join v in db.Vendors on vc.VendorID equals v.VendorID                                           
                               orderby vc.ContactID descending
                               select new
                               {
                                   VendorName = v.VendorName,
                                   FirstName = c.FirstName,
                                   MiddleName = c.MiddleName,
                                   LastName = c.LastName,
                                   ContactID = c.ContactID,
                                   VendorID = v.VendorID
                               })
                               .Distinct()
                               .Select(e => new ProviderContactInfo()
                               {
                                   VendorName = e.VendorName,
                                   FirstName = e.FirstName,
                                   MiddleName = e.MiddleName,
                                   LastName = e.LastName,
                                   Services = (from o in db.ContactServices
                                               join cps in db.Contacts on o.ContactID equals cps.ContactID
                                               join vps in db.Vendors on o.VendorID equals vps.VendorID
                                               join s in db.Services on o.ServiceID equals s.ServiceID
                                               where ps.ServiceID == o.ServiceID
                                               && o.ContactID == e.ContactID
                                               && o.VendorID == e.VendorID
                                               select s).ToList()
                               }).ToList();
