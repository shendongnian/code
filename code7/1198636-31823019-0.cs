    public ActionResult CreateApp(Guid id)
    {
        SMICParkingLotApplicationEntities1 dbb = new SMICParkingLotApplicationEntities1();
        ApplicationDATA applicationData = (from a in dbb.ApplicationDATAs
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
        ApplicationSlotViewModel applicationSlotViewModel = new ApplicationSlotViewModel
        {
            ApplicationDatas = applicationData,
            Application = new Application()
        };
        return View(applicationSlotViewModel);
