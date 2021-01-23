    var vm = new AssetViewModel
    {
       PsgcTagNumber =...,
       ...,
       Custodian =...,
       AllContacts = _custodian.Contacts
                     .Where(c => !(c.personid.StartsWith("RMR") || c.personid.StartsWith("GMS")))
                     .Select(c => new Contact { c.contactid, name = c.lname + ", " + c.fname})
                     .ToList(); 
    }
