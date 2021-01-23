    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var lst = new List<MonthSummary>();
            for (var m = DateTime.Today.AddMonths(-5); m <= DateTime.Today; m = m.AddMonths(1))
            {
                var summary = new MonthSummary();
                summary.Month = m;
                if (int.Parse(SelectedYear) == m.Year && int.Parse(SelectedMonth) == m.Month)
                    summary.MonthClass = "HighlightedMonth";
                else
                    summary.MonthClass = string.Empty;
                summary.NumberOfPosts = 0; // get the number of posts in an appropriate way
                if (summary.NumberOfPosts > 0)
                {
                    summary.ArchiveUrl = "~/BlogArchive?year=" + m.Year.ToString() + "&month=" + m.Month.ToString();
                    summary.ViewIndex = 0;
                }
                else
                {
                    summary.ArchiveUrl = string.Empty;
                    summary.ViewIndex = 1;
                }
                lst.Add(summary);
            }
            rptMonths.DataSource = lst;
            rptMonths.DataBind();
        }
    }
