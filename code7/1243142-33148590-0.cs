    protected void Page_Load(object sender, EventArgs e)
    {
        table = LoadTableFromDB();
        if (!IsPostBack)
        {
            calendar.VisibleDate = DateTime.Today;
            calendar.SelectedDate = DateTime.Today;
        }
    }
