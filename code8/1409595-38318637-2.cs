    /*
     *  assume Id becomes file ID key to download
     *  this code provides simple download function by returning FileContentResult with proper MIME type
     */
    public FileContentResult DownloadFile(int Id) 
    {
        // assume FileContext is your file list DB context with FileName property (file name + extension, e.g. Sample.mp3)
        using (FileContext db = new FileContext())
        {
            var download = db.TrackUploads.Where(x => x.ID == Id).SingleOrDefault();
            if (download != null) 
            {
                // remove this line if you want file download on the same page
                Response.AddHeader("content-disposition", "inline; filename=" + download.FileName);
                return File(download.FileName, "audio/mp3");
            }
            else
            {
                return null;
            }
        }
    }
