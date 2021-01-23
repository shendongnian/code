    [HttpPost]
    public void fileUpload(IEnumerable<HttpPostedFileBase> files)
    {
        foreach (var file in files)
        {
            // Validate size (in bytes), set your limit accordingly
            if (file.ContentLength > 0  && file.ContentLength <= 2097152)
            {
                // Do something with your files
            }
        }
    }
