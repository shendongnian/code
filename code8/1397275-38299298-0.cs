    protected void btnDownloadExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = GetReportData();
                if (dt.Rows.Count > 0)
                {
                    string fileName = drpReports.SelectedItem.ToString();
                    string attachment = "attachment;filename=" + fileName + ' ' + DateTime.Now.ToShortDateString() + ".xlsx";
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/vnd.ms-excel";
                    string tab = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Response.Write(tab + dc.ColumnName);
                        tab = "\t";
                    }
                    Response.Write("\n");
                    int i;
                    foreach (DataRow dr in dt.Rows)
                    {
                        tab = "";
                        for (i = 0; i < dt.Columns.Count; i++)
                        {
                            Response.Write(tab + dr[i].ToString());
                            tab = "\t";
                        }
                        Response.Write("\n");
                    }
                    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                    HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering in the HTTP pipeline chain of execution and directly execute the EndRequest event.
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "<script language='javascript'>alert('No records found. Please check the selection criteria.');</script>", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "<script language='javascript'>alert('Oops..!! some error occured. Please contact to administrator.');</script>", false);
                log4net.ThreadContext.Properties["loginid"] = LoggedInUserDetails.LoginId.ToString();
                Log.Error(ex.Message, ex);
            }
        }
