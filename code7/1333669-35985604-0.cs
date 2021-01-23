    public ActionResult GetPredictiveCourseTitleSearchResults()
        {
            var jsonbuilder = "";
            var q = HttpContext.Request.Params["q"];
            var year = HttpContext.Request.Params["year"];
            var callback = HttpContext.Request.Params["callback"];
            var model = new courseModel
            {
                SearchList = GetCourses(q,year)
            };
            var results = model.SearchList.Items.ToList();
            int count = results.Count();
            int resultCount = 0;
            if (callback != "")
            {
                jsonbuilder += callback + "(";
            }
            jsonbuilder += "[";
            foreach(var result in results)
            {
                if(resultCount+1 == count)
                {
                    jsonbuilder += "{\"title\":\"" + result.Fields["title"].ToString() + "\"}";
                }
                else
                {
                    jsonbuilder += "{\"title\":\"" + result.Fields["title"].ToString() + "\"},";
                }
                resultCount++;
            }
            jsonbuilder += "]";
            if (callback != "")
            {
                jsonbuilder += ")";
            }
            return new ContentResult { Content = jsonbuilder, ContentType = "application/json" };
            //return Json(jsonbuilder, JsonRequestBehavior.AllowGet);
        }
