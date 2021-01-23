    public ActionResult Uploade(UploadForm form)
    {
        if(form.file1 != null)
        {
            //handle file
        }
        
        foreach(var file in form.files)
        {
            if(file != null)
            {
                //handle file
            }
        }
        ...
    }
