    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            System.Diagnostics.Debugger.Break();
            MyCheckpoints myCheckpoints = new MyCheckpoints();
            List<CheckPoint> checkPoints = myCheckpoints.GetCheckPoins();
            int count = checkPoints.Count;
        }
    }
