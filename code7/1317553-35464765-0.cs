        public void SavePrescriber(string id)
        {
            var data = context.FullMasters.Where(x => x.NPI == id).FirstOrDefault();
     
            EPCS_Prescriber e = new EPCS_Prescriber();
            e.FirstName = data.FirstName;
            e.LastName = data.LastName;
            e.DeaNo = data.DEA;
            e.License = data.LIC;
            e.LifeNo = data.Life_Hosp;
            e.NpiNo = data.NPI;
            epcs.EPCS_Prescriber.AddObject(e);
            epcs.SaveChanges();
          
        }
