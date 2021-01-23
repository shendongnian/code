    public IList<SearchUserResult> SearchLegacyUsers(string userName, string email, string firstName, string lastName, string city, int? stateID, 
        string postalCode, int? countryID)
    {
        using (var db = new MyModel.MyContext())
        {
            var users = (from pu in db.PersonUsernames
                         from pe in db.PersonEmails
                                      .Where(a => a.PersonID == pu.PersonID)
                                      .DefaultIfEmpty()
                         from p in db.People
                                     .Where(b => b.UPID == pu.PersonID)
                                     .DefaultIfEmpty()
                         from pa in db.Addresses
                                      .Where(c => c.PersonID == pu.PersonID)
                                      .DefaultIfEmpty()
                         from sc in db.LU_State
                                      .Where(d => d.ID == pa.StateID)
                                      .DefaultIfEmpty()
                         from pp in db.Phones
                                      .Where(e => e.UPID == pu.PersonID)
                                      .DefaultIfEmpty()
                         // when you use DefaultIfEmpty, you're saying that 
                         // if this sequence does not contain any item
                         // it'll return a sequense with just 1 null item.
                         // So, you have to verify if pe, p, pa, sc and pp
                         // is different of null
                         select new SearchUserResult
                         {
                             PersonID = p.UPID,
                             UserName = pu.Username,
                             Email = pe.Email, // pe != null ? pe.Email : "",
                             FirstName = p.FirstName,
                             MiddleName = p.MiddleName,
                             LastName = p.LastName,
                             Address = pa.Address1,
                             City = pa.City,
                             StateCode = sc.StateAbbr,
                             StateID = sc.ID,
                             PostalCode = pa.Zip,
                             Phone = pp.PhoneNumber,
                             CountryCode = sc.LU_Country.Name,
                             CountryID = sc.LU_Country.ID
                         });
            if (!string.IsNullOrEmpty(userName))
                users = users.Where(a => a.UserName.Contains(userName));
            if (!string.IsNullOrEmpty(email))
                users = users.Where(b => b.Email != null && b.Email.Contains(email));
            if (!string.IsNullOrEmpty(firstName))
                users = users.Where(c => c.FirstName.Contains(firstName));
            if (!string.IsNullOrEmpty(lastName))
                users = users.Where(d => d.LastName.Contains(lastName));
            if (!string.IsNullOrEmpty(city))
                users = users.Where(e => e.City.Contains(city));
            if (stateID != null && stateID != 0)
            {
                users = users.Where(f => f.StateID == stateID);
            }
            if (!string.IsNullOrEmpty(postalCode))
                users = users.Where(g => g.PostalCode.Contains(postalCode));
            if (countryID != null && countryID != 0)
            {
                users = users.Where(h => h.CountryID == countryID);
            }
            // finally, you can execute the query
            return users.ToList();
        }
    }
