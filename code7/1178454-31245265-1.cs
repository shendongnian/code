    [WebMethod]
    public void DownloadReport()
    {
       string[] Params = Convert.ToString(HttpContext.Current.Request.Form["params"]).Split(',');
       string FileName = "Reports_";
       int reportId = Convert.ToInt32(Params[0]);
       int setId = Convert.ToInt32(Params[1]);
       DataTable dt = GetData(reportId,setId);
       ExportExcel obj = new ExportExcel();
       MemoryStream ms = obj.GenerateDocument(dt);
       HttpContext.Current.Response.Clear();
       HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
       HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + FileName + ".xlsx" + "\"");
       HttpContext.Current.Response.BinaryWrite(ms.ToArray());
       HttpContext.Current.Response.Flush();
       HttpContext.Current.Response.End();   
    }
