     if (!Directory.Exists("/Content/" + Session["user_id"] + "/"))
     {
           Directory.CreateDirectory("/Content/" + Session["user_id"] + "/");
     }
     if (FileUpload1.HasFile)
     {
           FileUpload1.PostedFile.SaveAs(Server.MapPath("/Content/" + Session["user_id"] + "/") + FileUpload1.FileName);
     }
