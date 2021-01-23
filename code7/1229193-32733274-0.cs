                System.IO.StringWriter objStringWriter1 = new System.IO.StringWriter();
                System.Web.UI.WebControls.GridView gridView1 = new System.Web.UI.WebControls.GridView();
                System.Web.UI.HtmlTextWriter objHtmlTextWriter1 = new System.Web.UI.HtmlTextWriter(objStringWriter1);
    
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Charset = "";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
    
                gridView1.DataSource = tempDataTable;
                gridView1.DataBind();
                gridView1.RenderControl(objHtmlTextWriter1);
    
                gridView1.Dispose();
                HttpContext.Current.Response.Write(objStringWriter1.ToString());
    
                HttpContext.Current.Response.End();
