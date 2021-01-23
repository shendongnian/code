    public override void VerifyRenderingInServerForm(Control control)
            {
                /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
                   server control at run time. */
            }
            protected void ExportExcel(object sender, EventArgs e)
            {
                grvPayroll.AllowPaging = false;
                var grvPayrollDetails = new GridView();
                for (var i = 0; i < grvPayroll.Rows.Count; i++)
                {
                    grvPayrollDetails = (GridView)grvPayroll.Rows[i].FindControl("grvPayrollDetails");
                    grvPayrollDetails.AllowPaging = false;
                    BindGrid(SortField);
                }
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=PayrollExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grvPayrollDetails.AllowPaging = false;
                    this.BindGrid(SortField);
                    grvPayrollDetails.Font.Name = "Times New Roman";
                    grvPayrollDetails.BackColor = Color.Transparent;
                    grvPayrollDetails.GridLines = GridLines.Both;
                    grvPayrollDetails.RenderControl(hw);
                    Response.Write(Regex.Replace(sw.ToString(), "(<a[^>]*>)|(</a>)", " ", RegexOptions.IgnoreCase));
                    Response.Flush();
                    Response.End();
                }
               
            }
