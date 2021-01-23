    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            DataTable dtParent = new DataTable();
            DataTable dtChild = new DataTable();
            string[] column = { "PreferredInd", "ExcludedInd" };
            // Loop & Create Column
            for (int i = 0; i < column.Length; i++)
            {
                dtParent.Columns.Add(column[i], typeof(bool));
                dtChild.Columns.Add(column[i], typeof(bool));
            }
            
            // Create Rows
            for(int i = 0; i< 1; i++)
            {
                dtParent.Rows.Add(false, false);
                dtChild.Rows.Add(false, false);
            }
            // ViewState Child DataTable
            ViewState["DataChild"] = dtChild;
            // Bind
            agVendorExcl.DataSource = dtParent;
            agVendorExcl.DataBind();
        }
    }
    protected void agVendorExcl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Check
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Find Control
            Image imgDocPlus = e.Row.FindControl("imgDocPlus") as Image;
            Panel pnlVendorAssociates = e.Row.FindControl("pnlVendorAssociates") as Panel;
            GridView agVendorExclAssociates = e.Row.FindControl("agVendorExclAssociates") as GridView;
            // Check
            if (agVendorExclAssociates != null)
            {
                // Bind Sub GridView
                agVendorExclAssociates.DataSource = ViewState["DataChild"] as DataTable;
                agVendorExclAssociates.DataBind();
            }
            imgDocPlus.Attributes.Add("onclick", "collapseExpand('" + imgDocPlus.ClientID + "', '" + pnlVendorAssociates.ClientID + "')");
        }
    }
    protected void chkExcluded_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (sender as CheckBox);
        if (chkAll != null)
        {
            GridViewRow row = chkAll.NamingContainer as GridViewRow;
            
            if (row != null)
            {
                GridView agVendorExclAssociates = (GridView)row.FindControl("agVendorExclAssociates");
                Panel pnlVendorAssociates = row.FindControl("pnlVendorAssociates") as Panel;
                // Show After Your Value is Checked else Hide
                pnlVendorAssociates.Style.Add(HtmlTextWriterStyle.Display, chkAll.Checked ? "" : "none");
                foreach (GridViewRow gvRow in agVendorExclAssociates.Rows)
                {
                    // Find Control
                    CheckBox chkBox = (CheckBox)gvRow.FindControl("chkAssoExcluded");
                    // Check
                    if (chkAll.Checked) chkBox.Checked = true;
                    else chkBox.Checked = false;
                }
            }
        }
    }
