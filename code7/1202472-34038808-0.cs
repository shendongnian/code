    public class PSI
    {
        private ProjectContext _context;
        private string basicEpt = "Enterprise Project";   // Basic enterprise project type.
        private static readonly PSI psi = new PSI();
        private int timeoutSeconds = 60;
        SvcProject.ProjectClient _prClient;
        private PSI ()
	    {
            _context = new ProjectContext(System.Configuration.ConfigurationManager.AppSettings["PwaUrl"]);
			//credentials of currently running acount or enable line below
            //_context.Credentials = new System.Net.NetworkCredential("user", "pass", "domain");
            timeoutSeconds = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DefaultTimeoutPwa"]);
            _prClient = new SvcProject.ProjectClient("basicHttp_Project");
  	    }
        public static PSI Instance
        {
            get{ return psi; }
        }
        public Guid GetEptUid(string eptName)
        {
            Guid eptUid = Guid.Empty;
            try
            {
                var eptList = _context.LoadQuery( _context.EnterpriseProjectTypes.Where(ept => ept.Name == eptName));
                _context.ExecuteQuery();
                eptUid = eptList.First().Id;
            }
            catch (Exception ex)
            {
                string msg = string.Format("GetEptUid: eptName = \"{0}\"\n\n{1}", eptName, ex.GetBaseException().ToString());
                throw new ArgumentException(msg);
            }
            return eptUid;
        }
        public PublishedProject CreateProject(string prName, string description, DateTime startDate)
        {
            try
            {
                System.Console.Write("\nCreating project: {0} ...", prName);
                ProjectCreationInformation newProj = new ProjectCreationInformation();
                newProj.Id = Guid.NewGuid();
                newProj.Name = prName;
                newProj.Description = description;
                newProj.Start = startDate;
                newProj.EnterpriseProjectTypeId = GetEptUid(basicEpt);
                PublishedProject newPublishedProj = _context.Projects.Add(newProj);
                QueueJob qJob = _context.Projects.Update();
                JobState jobState = _context.WaitForQueue(qJob, timeoutSeconds);
                if (jobState == JobState.Success)
                    return newPublishedProj;
                else
                    return null;
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("\nError: {0}", ex.Message);
                System.Console.ResetColor();
                return null;
            }
        }
	}
