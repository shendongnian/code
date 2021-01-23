    public IQueryable<VendorContact> GetProviderContactInfo(ProviderContactInfo searchInfo)
    {
      using (var db = new MyContext()) 
      {
        return providerContactInfo=db.VendorContacts
          .Include(vc=>vc.Contacts)
          .Include(vc=>vc.Services)
          .Include(vc=>vc.Vendor)
          .OrderByDescending(vc=>vc.ContactID);
      }
    }
