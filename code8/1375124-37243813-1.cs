    public void GenerateFile(string template, Dictionary<string, string> data)
        {
            try {
                DocX dDocument;
                
                dDocument = DocX.Load(template);
                
                foreach (var item in data)
                {
                    dDocument.ReplaceText("[["+item.Key+"]]", item.Value);
                    
                }
                var path = HttpContext.Current.Server.MapPath("~/temp/" + Path.GetFileNameWithoutExtension(template) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".doc");
                dDocument.SaveAs(path);
                downloadFile(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
            }
