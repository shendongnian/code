    var applicationData =dbb.ApplicationDATAs.FirstOrDefault(a=>a.ApplicationID == id);
    ApplicationSlotViewModel applicationSlotViewModel = new ApplicationSlotViewModel
    {
            ApplicationDatas = applicationData,
            Application = new Application()
    };
