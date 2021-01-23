        var applicationData = (from a in dbb.ApplicationDATAs
            where a.ApplicationID == id
            select new 
            {
                ApplicationID = a.ApplicationID,
                BrandModel = a.BrandModel,
                CrNo = a.CrNo,
                OrNo = a.OrNo,
                DatePosted = a.DatePosted,
                PoR = a.PoR,
                PlateNo = a.PlateNo,
                VehicleType = a.VehicleType
            }).FirstOrDefault();
        
