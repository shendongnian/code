    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Load all applications
            var apps = loadAllApplications();
            //Load user applications
            var myApps = loadUserApplications();
            //Bind to checkboxlist, assuming my checkboxlist ID "chksApps"
            chksApps.DataSource = apps.Select(x => new ListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = myApps.Any(a => x.Id == a)
            });
            chksApps.DataBind();
        }
    }
    //lets say I have a Application class like that
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    private List<int> loadUserApplications()
    {
        // if user already have "Paint", "Chrome" assigned
        var myApps = new List<int>() { 2, 4 };
        return myApps;
    }
    private List<Application> loadAllApplications()
    {
        //for testing I will create a dummy list of applications
        var applications = new List<Application>() { 
            new Application { Id = 1, Name = "Visual Studio" },
            new Application { Id = 2, Name = "Paint" },
            new Application { Id = 3, Name = "Notepad" },
            new Application { Id = 4, Name = "Chrome" }
        };
        return applications;
    }
