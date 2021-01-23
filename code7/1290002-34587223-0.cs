                    //Write the decrypted text to folder in the server.
                    System.IO.File.WriteAllText(Server.MapPath("~/Decrypted Files/" + FileName), plainText);
                    
                    //Code for Download
                    Response.Clear();
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "attachment; filename='" + FileName + "'");
                    Response.WriteFile(Server.MapPath("~/Decrypted Files/" + FileName));
                    Response.Flush();
    
                    //Delete File from the folder
                    if (System.IO.File.Exists(Server.MapPath("~/Decrypted Files/" + FileName)))
                    {
                        System.IO.File.Delete((Server.MapPath("~/Decrypted Files/" + FileName)));
                    }
                    HttpContext.Current.Response.End();
