        private void UserDownload(string fileOutPutName, string fileType, string fileContentPath)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlPathEncode(fileOutPutName));
            Response.ContentType = fileType;
            try
            {
                Response.WriteFile(fileContentPath);
            }
            catch
            {}
            Response.End();
        }
