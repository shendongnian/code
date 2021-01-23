                    grdMessage.DataSource = resultsDataTable;
                    grdMessage.DataBind();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    System.IO.StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grdMessage.RenderControl(hw);
                }
