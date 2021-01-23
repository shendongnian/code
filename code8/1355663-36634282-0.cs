    protected void Page_Load(object sender, EventArgs e)
    {
        int lifelineid;
        int phaseid;
        hideAndShow();
        if (!IsPostBack)
        {
            lifelineid = 22222;
            phaseid = 1;
        }
        else
        {
            lifelineID = Convert.ToInt32(TextBox1.Text);
            phaseid = Convert.ToInt32(TextBox2.Text);
        }
        FillFaseTable(PhaseMainTable, phaseid, lifelineid);
        PhasePanel.CssClass = "panel col-lg-2 col-md-2 col-xs-2 Phase1BackgroundColor";
    }
