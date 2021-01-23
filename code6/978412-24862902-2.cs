    protected void gvtotqty_onselectedindexchanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvtotqty.Rows)
        {
            if (row.RowIndex == gvtotqty.SelectedIndex)
            {
                Session["rowindex"]=row.RowIndex;
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                row.ToolTip = string.Empty;
                row.Attributes["onclick"] = "";
    
            }
            else
            {
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                row.ToolTip = "Click to select this row.";
                row.Attributes["onclick"] =     Page.ClientScript.GetPostBackClientHyperlink(gvtotqty, "Select$" + row.RowIndex);
            }
        }
    }
