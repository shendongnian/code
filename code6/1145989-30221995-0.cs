    public ActionResult DownloadTemplate(string templateName)
            {
                using (var service = new MyService())
                {
                    var template = service.GetEmailTemplateByName(templateName);
                    string attachment = string.Format("attachment; filename={0}_TEMPLATE.html", templateName);
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "text/html";
                    Response.Write(template.Body);
                    Response.End();
                    return new EmptyResult();
                }
            }
