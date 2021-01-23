    public ActionResult WedstrijdViewMain(int OrgID, int TeamID)
        {
           DBService.DataServiceClient DBObject = new DBService.DataServiceClient();//Create Object of your service
                var wedstrijden = DBObject.GetWedstrijd(TeamID, OrgID);
           return View(WedService);
        }
