    public static void ExportToExcel(ref GridView gv, string _filename, string cmplbl)
    {
        string style = @"<style>.text{mso-number-format:\@;text-align:center;};.Nums{mso-number-format:_(* #,###.00_);};.unwrap{wrap:false}</style>";
        //string style = @"<style> .text { mso-number-format:\@; } </style> ";
        // "<style>.text{mso-number-format:\@;text-align:center;};.Nums{mso-number-format:_(* #,##0.00_);};.unwrap{wrap:false}</style>"
        string attachment = "attachment; filename=" + _filename;
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.AddHeader("content-disposition", attachment);
        // If you want the option to open the Excel file without saving then;
        // comment out the line below
        // Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment;Filename=Orders.xls");
        //Response.Write ("<meta http-equiv=""Content-Type"" content=""text/html; charset=Utf-8"">")
        StringWriter sw = new StringWriter(); HtmlTextWriter htw = new HtmlTextWriter(sw);
        gv.RenderControl(htw);
        StringBuilder name = new StringBuilder();
        name.Append(cmplbl);
        HttpContext.Current.Response.Write(style);
        HttpContext.Current.Response.Write(name.Append(sw.ToString()));
        //HttpContext.Current.Response.Write(sw.ToString());
        HttpContext.Current.Response.End(); 
        
        //HttpContext.Current.Response.WriteFile(_filename);
        //Response.ContentType = "application/vnd.ms-excel"
        //Response.AddHeader("Content-Disposition", "attachment;Filename=Orders.xls")
        //Response.Write ("<meta http-equiv=""Content-Type"" content=""text/html; charset=Utf-8"">")
        //dbGrid_Orders.RenderControl(hw)
        //Response.Write(tw.ToString())
        //Response.End()
    }
    private void ExportGridView(GridView gvFiles, string filePath, string fileName)
    {
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        // Render grid view control.
        gvFiles.RenderControl(htw);
        // Write the rendered content to a file.
        string renderedGridView = sw.ToString();
        System.IO.File.WriteAllText(filePath + fileName, renderedGridView);
        //Response.Clear(); 
        //Response.ContentType = "application/octect-stream";
        //Response.AppendHeader("content-disposition", "filename=" + fileName);
        //Response.TransmitFile(filePath + fileName); 
        //Response.End();
        System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;
        response.ClearContent();
        response.Clear();
        response.ContentType = "text/plain";
        response.AddHeader("Content-Disposition",
                           "attachment; filename=" + fileName + ";");
        response.TransmitFile(filePath + fileName);
        response.Flush();
        response.End();
    }
 
