                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Buffer = true;
             
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.ClearHeaders();
                    HttpContext.Current.Response.AddHeader("Cache-control", "no-store");
                    var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
                    if (userAgent.Contains("iphone;"))
                    {
                        HttpContext.Current.Response.ClearHeaders();
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Claim_Report_" + strFileName + ".pdf"));
                    }
                    else if (userAgent.Contains("ipad;"))
                    {
                        HttpContext.Current.Response.ClearHeaders();
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ContentType = "application/octet-stream";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Claim_Report_" + strFileName + ".pdf"));
                    }
                    else
                    {
                        HttpContext.Current.Response.ContentType = "application/pdf";
                        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Claim_Report_" + strFileName + ".pdf"));
                    }
                   
                    HttpContext.Current.Response.BinaryWrite(Buffer);
                    //HttpContext.Current.Response.End();
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
