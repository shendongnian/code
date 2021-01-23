    var job = model.vm.Where(i => i.JobseekerId == id).SingleOrDefault();
        if(job!=null)
        {
                        model.FirstName = job.FirstName;
                        model.LastName = job.LastName;
                        model.EmailID = job.EmailID;
                        model.JobTitle = job.JobTitle;
                        model.Location1 = job.Location1;                
                        model.University = job.University;
                        model.TechnicalExp = job.TechnicalExp;
                        model.WorkField = job.WorkField;
        }
