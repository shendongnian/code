        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (jvGrid.Rows.Count > 0)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Jv entries_" + cboQuater.SelectedValue +" qtr " + cboYear.SelectedValue + ".xlsx");
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    
                StringWriter sw = new StringWriter();
                jvGrid.HeaderRow.Style.Add("background-color", "#fff");
                jvGrid.HeaderRow.Style.Add("color", "#000");
                jvGrid.HeaderRow.Style.Add("font-weight", "bold");
    
                for (int i = 0; i < jvGrid.Rows.Count; i++)
                {
                    GridViewRow grow = jvGrid.Rows[i];
                    grow.BackColor = System.Drawing.Color.White;
                    grow.Attributes.Add("class", "textmode");
                }
    
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    jvGrid.RenderControl(hw);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
    
            }
    }
