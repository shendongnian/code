      public System.Web.Mvc.ActionResult RemoveVersions()
      {
        // select user ids, an alternate way is to retrieve user IDs via content manager but this takes a veeeeery long time due
        // to the need of querying all versions
        //
        // mContentManager
        //  .Query<Orchard.Users.Models.UserPart, Orchard.Users.Models.UserPartRecord>(Orchard.ContentManagement.VersionOptions.AllVersions)
        //  .List()
        //  .Select(u => u.Id)
        //  .ToList()
        var lOrchardUserIDs = mUserRepository.Fetch(u => true).Select(u => u.Id).ToList();
        lOrchardUserIDs = mContentManager
          .Query<Orchard.Users.Models.UserPart, Orchard.Users.Models.UserPartRecord>(Orchard.ContentManagement.VersionOptions.AllVersions)
          .List()
          .Select(u => u.Id)
          .ToList();
                  
        foreach (var lOrchardUserID in lOrchardUserIDs)
        {
          var lContentItemVersionRecords =
            (from r in DataContext.ContentItemVersionRecords where r.ContentItemRecord_id == lOrchardUserID select r).ToList();
          if (lContentItemVersionRecords.Count > 1)
          {
            foreach (var lContentItemVersionRecord in lContentItemVersionRecords)
            {
              if (lContentItemVersionRecord.Number == 1)
              {
                lContentItemVersionRecord.Latest = true;
                lContentItemVersionRecord.Published = true;
              }
              else
                DataContext.ContentItemVersionRecords.DeleteOnSubmit(lContentItemVersionRecord);
            }
          }
        }
        DataContext.SubmitChanges();
        
        return Content("Done");
      }
