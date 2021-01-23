    public  void GridToExcel()
    {
        if (berthOccupancyDataGridView.Rows.Count > 0)
        {
            Response.Clear();
            //HttpContext.Current.Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=BerthOccupancy.xls");
            //HttpContext.Current.Response.Charset = "";
            Response.ContentType = "text/csv";
    
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            berthOccupancyDataGridView.RenderControl(htw);
           
            if (Global.ReportType == "Year To Date")
            {
                foreach (GridView gv in Global.GridViewList)
                {
                    gv.RenderControl(htw);
                }
            }
            else if(Global.ReportType == "Monthly")
            {
                recapGridView.RenderControl(htw);
    
            }
    
            Response.Write(sw.ToString());
            Response.End();
        }
    }
