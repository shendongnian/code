      protected void Show_Hide_AccountingPlansGrid(object sender, EventArgs e)
        {
            try
            {
                ImageButton imgShowHide = (sender as ImageButton);
                GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
                if (imgShowHide.CommandArgument == "Show")
                {
                 ...
                    imgShowHide.CommandArgument = "Hide";
                    imgShowHide.ImageUrl = "/Content/img/minus.gif";
                    row.FindControl("trAccountingPlan").Visible = true;
                    HtmlTableCell tdAccountingPlan = (HtmlTableCell)row.FindControl("tdAccountingPlan");
                    HtmlTableCell tdAccountingPlan2 = (HtmlTableCell)row.FindControl("tdAccountingPlan2");
                    tdAccountingPlan2.Visible = true;
                    tdAccountingPlan.Visible = true;
                                 
                  ...
                 
                }
                else
                {                    
                    imgShowHide.CommandArgument = "Show";
                    imgShowHide.ImageUrl = "/Content/img/plus.gif";
                    row.FindControl("trAccountingPlan").Visible = false;
                    HtmlTableCell tdAccountingPlan = (HtmlTableCell)row.FindControl("tdAccountingPlan");
                    HtmlTableCell tdAccountingPlan2 = (HtmlTableCell)row.FindControl("tdAccountingPlan2");
                    tdAccountingPlan2.Visible = false;
                    tdAccountingPlan.Visible = false;
                }
            }
            catch (Exception ex) { GlobalHelpers.Trace(ex); }
        }
