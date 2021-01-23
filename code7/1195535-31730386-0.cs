    protected void btnExportData_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=output.xlsx");
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
        foreach (GridViewRow row in gvData.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
                for (int idxColumn = 0; idxColumn < row.Cells.Count; idxColumn++)
                    row.Cells[idxColumn].Attributes.Add("class", "xlText");
        }
        
        gvData.RenderControl(htmlWriter);
        
        string appendStyle = @"<style> .xlText { mso-number-format:\@; } </style> ";
        Response.Write(appendStyle);
      
        Response.Write(sw.ToString());
        Response.End();
    }
