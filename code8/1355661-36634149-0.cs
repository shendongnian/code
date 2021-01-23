    protected void LoadLifeLineBtn_Click(object sender, EventArgs e)
    {
        hideAndShow();
        int lifelineID = Convert.ToInt32(TextBox1.Text);
        int phaseid = Convert.ToInt32(TextBox2.Text);
    
        FillFaseTable(PhaseMainTable, phaseid, lifelineid);
        PhasePanel.CssClass = "panel col-lg-2 col-md-2 col-xs-2 Phase1BackgroundColor";
    }
