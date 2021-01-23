          foreach (var item in db.SystemFamily.ToList())
          {
            int id = item.SystemFamilyID;
            //SystemsCount 
            int count = db.Systems.Where(x => x.SystemFamilyID == id).Count();   
            item.SystemsCount = count;
         }
