        private void downloadAnImage(string strImage)
	    {
		    Response.ContentType = "image/jpg";
		    Response.AppendHeader("Content-Disposition", "attachment; filename=" + strImage);
		    Response.TransmitFile(strImage);
            Response.Flush();
		    Response.End();
	    }
