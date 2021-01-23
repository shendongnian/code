     [ChildActionOnly]
        public ActionResult GetCommodityReportFilter(LikeFilterModel modelObj)
        {
            LikeFilterModel model = null;
            if (Request.HttpMethod != "POST")
            {
                ModelState.Clear(); // add this
                model = new LikeFilterModel();
                model.ReportName = ReportType.Commodity;
            }
            else
                model = modelObj;
            return GetLikeFilter(model);
        }
