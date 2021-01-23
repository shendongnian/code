    public ActionResult Checkfunction(string ReqID, string AssociateId, string AssetId)
    {
          MyDetails obj = new MyDetails();
          List<string> Lst = new List<string>();
          Lst = objMyAssetsDetails.Check(AssociateId, AssetId, ReqID);
          return this.Json(Lst, "text/json", JsonRequestBehavior.AllowGet );
    }
