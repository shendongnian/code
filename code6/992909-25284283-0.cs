     [HttpGet]
        public ActionResult ShowTask()
        {
            ShowTask model = new ShowTask();
            var TaskData = (from d in edc.TaskTBs
                            join d1 in edc.TaskToUserTBs on d.TaskID equals d1.TaskID
                            where d.IsActive == true && d1.RegistrationId == Convert.ToInt32(Session["RegistrationId"])
                            select new
                            {
                                d.ProjectTB.ProjectName,
                                d1.RegistrationId,
                                d.TaskID,
                                d.DBName,
                                d.Description,
                                d.FromDate,
                                d.ToDate,
                                d.ProjectID,
                                d1.RegistrationTB.Name,
                                d1.RegistrationTB.Email
                            }).OrderByDescending(x => x.TaskID).ToList();
            if (TaskData != null)
            {
                if (model.FromSearchDate.ToString() != "" && model.FromSearchDate.ToString() != "1/1/0001 12:00:00 AM")
                {
                    TaskData = TaskData.Where(x => x.FromDate.Contains(model.FromSearchDate.ToString())).ToList();
                }
                if (model.FromSearchDate.ToString() != "" && model.ToSearchDate.ToString() != "1/1/0001 12:00:00 AM")
                {
                    TaskData = TaskData.Where(x => x.ToDate.Contains(model.ToSearchDate.ToString())).ToList();
                }
                model.Tasklist = TaskData;
            }
            return View(model);
        }
