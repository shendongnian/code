            Response.AppendHeader("content-disposition", "attachment;filename=ExportToExcel.xls");
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            this.EnableViewState = false;
            Response.Write(HTMLDiv.InnerHtml);
            Response.End();
