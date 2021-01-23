        string Jurisdiction = "Alabama, Alaska, Arizona";
        string IssueDate = "12/10/2015";
        FillJurisdictionGrid(Jurisdiction, IssueDate);
    }
    private void FillJurisdictionGrid(string Jurisdiction, string IssueDate)
    {
        if (Jurisdiction != "")
        {
            grdView.Visible = true;
            //grid.Visible = true;
            //txtJurisdiction.Enabled = false;
            string[] jurisdictionData = Jurisdiction.Split(',');
            grdView.DataSource = jurisdictionData;
            grdView.DataBind();
            for (int i = 0; i < grdView.Rows.Count; i++)
            {
                TextBox txtEffectiveDate = (TextBox)grdView.Rows[i].FindControl("txtEffectiveDate");
                txtEffectiveDate.Text = IssueDate;//By chance you want to pass the Textbox Value
            }
        }
        else
        {
            //  grid.Visible = false;
            grdView.Visible = false;
        }
    }
