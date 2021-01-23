    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var lst = new List<MonthSummary>();
            for(var m = DateTime.Today.AddMonths(-5); m <= DateTime.Today; m = m.AddMonths(1))
            {
                 var summary = new MonthSummary(); 
                 summary.Month = m;
                 if (int.Parse(SelectedYear) == m.Year && int.Parse(SelectedMonth) == m.Month)
                     summary.MonthClass = "HighlightedMonth";
                 else 
                     summary.MonthClass = string.Empty;
                 summary.NumberOfPosts = numberOfPosts; // get the number of posts in an appropriate way
                 if (summary.NumberOfPosts > 0)
                     summary.ArchiveUrl = "~/BlogArchive?year=" + m.Year.ToString() + "&month=" + m.Month.ToString();
                 else 
                     summary.ArchiveUrl = string.Empty;
                 lst.Add(summary);
            }
            rpt.DataSource = lst;
            rpt.DataBind();
        }
    }
