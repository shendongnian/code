    public ActionResult Download()
    {
    	using (ZipFile zip = new ZipFile())
    	{
    		zip.AddDirectory(Server.MapPath("~/Directories/hello"));
    
    		MemoryStream output = new MemoryStream();
    		zip.Save(output);
    		return File(output.ToArray(), "application/zip", "sample.zip");
        }  
    }
