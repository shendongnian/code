    ViewState["MediaFile"] ="mediaUploader/Visual2.pdf";
    
     if (ViewState["MediaFile"] != null)
     {
    	 String sFile = Server.MapPath("~/" + ViewState["MediaFile"].ToString());
    	 FileInfo file = new FileInfo(sFile);
    	 if (file.Exists)
    	 {
    		 Response.ContentType = "application/pdf";
    		 Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name);
    		 Response.TransmitFile(Server.MapPath("~/" + ViewState["MediaFile"].ToString()));
    		 Response.End();
    	 }
     }
