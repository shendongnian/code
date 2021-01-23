    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file)
    {
        if (file.ContentLength > 0) // check a file was selected
        {
           // Initialize a new instance of the data model and set its properties
           ImageGallery model = new ImageGallery()
           {
               FileName = file.FileName,
               ImageSize = file.ContentLength,
               ....
           };
           .... // save and redirect
        }
        else {
          // add a model state error and return the view?
        }
    }
