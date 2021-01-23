    public void InsertApplication(Application application)
    {
        if (application.Applicants != null)
        {
            foreach (var item in application.Applicants)
            {
                if (item.Employments != null)
                {
                    application.NumberOfEmployments += item.Employments.Count();
                }
            }
        }
        creditApplicationsContext.Applications.Add(application);
    }
