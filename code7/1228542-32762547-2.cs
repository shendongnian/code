    var result = ctx.PersonEntity
    .Where(c => c.Addresses.FirstOrDefault(X = > X.IsPrimary == true)).ToList();
    var personViewModels = result
    .Select(c => new PersonViewModel{
    PersonId = c.PersonId ,
    FirstName = c.FirstName , 
    LastName = c.LastName,  
    AddressLine1 = c.Addresses != null ? c.Addresses.FirstOrDefault().AddressLine1 : String.Empty , 
    AddressLine2 = c.Addresses != null ? c.Addresses.FirstOrDefault().AddressLine2 : String.Empty ,  
    AddressLine3 = c.Addresses != null ? c.Addresses.FirstOrDefault().AddressLine3 : String.Empty  });
