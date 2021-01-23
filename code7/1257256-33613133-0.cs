    [HttpGet]
    public Models.CustomerAddress Add(Guid CompanyRef, string ContactNo, Guid CustomerRef, string DOE, string Email, string FName, string SName,
        Guid? addressRef, string add1, string add2, string add3, string town, string county, string pCode, string country)
    {
        var res= customerRepository.Add(CompanyRef, ContactNo, CustomerRef, DOE, Email, FName, SName,
             addressRef,  add1,  add2,  add3,  town,  county,  pCode,  country);
        return new Models.CustomerAddress {
            AddressRef =res.AddressRef,
            CustomerRef =res.CustomerRef,
            CustomerExists=  (res.CustomerRef==CustomerRef)? true : false
        };
    }
