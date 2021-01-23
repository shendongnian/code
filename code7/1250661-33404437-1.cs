    protected void btnPanel1_Click(object sender, EventArgs e)
    {
        if (!pnl1.HasControls())
        {
            pnl1.Attributes.Add("style", "width: 100%;");
            HtmlGenericControl pnlDiv = new HtmlGenericControl("div");
            pnlDiv.ID = "pnlDiv1";
            pnlDiv.Attributes.Add("style", "width: 100%; text-align:center;");
            
            Label lbl = new Label();
            lbl.ID = "lblSomething";
            lbl.Text = "Panel 1 Something";
            lbl.Font.Bold = true;
            lbl.Font.Size = 16;
            lbl.Attributes.Add("style", "position: absolute; top: 50%; bottom: 50%; left: 0; right: 0;");
            pnlDiv.Controls.Add(lbl);
            pnl1.Controls.Add(pnlDiv);
        }
        pnl1.Visible = true;
        pnl2.Visible = false;
    }
    protected void btnPanel2_Click(object sender, EventArgs e)
    {
        if (!pnl2.HasControls())
        {
            pnl2.Attributes.Add("style", "width: 100%;");
            HtmlGenericControl pnlDiv = new HtmlGenericControl("div");
            pnlDiv.ID = "pnlDiv2";
            pnlDiv.Attributes.Add("style", "width: 100%; text-align:center;");
            Label lbl = new Label();
            lbl.ID = "lblSomething2";
            lbl.Text = "Panel 2 Something";
            lbl.Font.Bold = true;
            lbl.Font.Size = 16;
            lbl.Attributes.Add("style", "position: absolute; top: 50%; bottom: 50%; left: 0; right: 0;");
            pnlDiv.Controls.Add(lbl);
            pnl2.Controls.Add(pnlDiv);
        }
        pnl1.Visible = false;
        pnl2.Visible = true;
    }
