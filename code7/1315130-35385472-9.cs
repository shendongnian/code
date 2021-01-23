    [HttpPost]
    public IActionResult Create(CreatePost model)
    {
       var img = model.MyImage;
       var imgCaption = model.ImageCaption;
       //Getting file meta data
       var fileName = Path.GetFileName(model.MyImage);
       var contentType= model.ContentType;
       // do something with the above data
       // to do : return something
    }
