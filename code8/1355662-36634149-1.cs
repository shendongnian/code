    protected void Page_Load(object sender, EventArgs e)
    {
        hideAndShow();
        if (!IsPostBack)
        {
            lifelineid = 22222;
            phaseid = 1;
            FillFaseTable(PhaseMainTable, phaseid, lifelineid);
            PhasePanel.CssClass = "panel col-lg-2 col-md-2 col-xs-2 Phase1BackgroundColor";
        }
    }
