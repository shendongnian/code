        public String DownloadExcel(string data, string fileName)
        {
            var name = String.IsNullOrEmpty(fileName) ? "Export" : fileName;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AppendHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", name));
            Response.AppendHeader("Cache-Control", "max-age=1, must-revalidate");
            return HttpUtility.HtmlDecode(String.IsNullOrEmpty(data) ? Request["Data"] : data);
        }
