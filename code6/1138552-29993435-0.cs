    private List<JobsiteNote> _jobsiteNotes = null;
    public List<JobsiteNote> JobsiteNotes 
    { 
        get
        {
             if (_jobsiteNotes == null)
              {
                _jobsiteNotes = this.Jobsite.JobsiteNotes.OrderByDescending(x => x.CreatedOn).ToList();
              }
              return _jobsiteNotes;
        }
    }
