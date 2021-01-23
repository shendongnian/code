    public class JobLogic : GenericLogic<Job>
    {
        #region Fields
        public Job Job { get; set; }    
        public IEnumerable<SelectListItem> JobTypeList { get; set; }
        #endregion
        #region Constructor
        public JobLogic()
        {
            Job = new Job();
            JobTypeList = GetJobTypeList();
        }
        #endregion
        #region Methode
        private IEnumerable<SelectListItem> GetJobTypeList()
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Repository<JobType> jobTypeEngine = unitOfWork.Repository<JobType>();   
            var jobs = jobTypeEngine.List
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.Name
                                });
            return new SelectList(jobs, "Value", "Text");
        }
        #endregion
    }
