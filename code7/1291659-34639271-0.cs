    protected void ExportData(string fileName, string fileType, string content)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlPathEncode(fileName));
            Response.Charset = "";
            Response.ContentType = fileType;
            Response.Output.Write(content);
            Response.Flush();
            Response.End();
        }
