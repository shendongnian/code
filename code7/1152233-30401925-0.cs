    DataTable dtJobs
    {
        get { if (Cache["dtJobs"] == null) Cache["dtJobs"] = Provider.Job.getAll(); return (DataTable)Cache["dtJobs"]; }
        set { if (value != null) Cache.Insert("dtJobs", value, null, DateTime.Now.AddMinutes(5d), System.Web.Caching.Cache.NoSlidingExpiration);
              else Cache.Remove("dtJobs");
        }
    }
