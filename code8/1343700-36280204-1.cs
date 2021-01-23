    [HttpPost]
            public JsonResult AddTfsFeature(string requestNo, string teamProjectCollection, string project)
            {
                ResultMessageViewModel result = new ResultMessageViewModel
                {
                    Result = "Failed",
                    Message = "No data"
                };
    
                TfsFeature feature = new TfsFeature
                {
                    ID = sessTempIndexTfsFeature,
                    RequestNo = requestNo,
                    TeamProjectCollection = teamProjectCollection,
                    Project = project,
                    CreatedBy = UserID
                };
                for (int i = 0; i < sessListTfsFeature.Count; i++)
                {
                    if (sessListTfsFeature.ElementAt(i).TeamProjectCollection == teamProjectCollection &&
                        sessListTfsFeature.ElementAt(i).Project == project)
                    {
                        result.Result = "Failed";
                        result.Message = "Existing feature data has already exist.";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                sessListTfsFeature.Add(feature);
    
            result.Result = "Success";
            result.Message = "Add Success";
            result.TempObject = feature;
            result.TempObjectCount = sessListTfsFeature.Count;
            return Json(result, JsonRequestBehavior.AllowGet);
