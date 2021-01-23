    public void GenerateFile(string template, Dictionary<string, string> data)
        {
            try { 
            //if (File.Exists(template))
            //{
                DocX dDocument;
                
                dDocument = DocX.Load(template);
                
                foreach (var item in data)
                {
                    dDocument.ReplaceText(item.Key, item.Value);
                    
                }
                string time = DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString();
                var path = HttpContext.Current.Server.MapPath("~/temp/" + Path.GetFileNameWithoutExtension(template) + "_" + time + ".doc");
                dDocument.SaveAs(path);
                downloadFile(path);
             //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
                
            }
