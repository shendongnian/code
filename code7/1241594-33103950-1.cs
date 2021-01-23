    ...
    var entity = db.ApplicationUsers.FirstOrDefault(x => x.Id == 1);
    if (entity != null) 
    {
        var model = new ViewImagesViewModel();
        model.UserFirstName = entity.UserFirstName;
        model.UserSurname = entity.UserSurname;
        model.City = entity.City;
        // fix the Image property in the ApplicationUser entity to be Images instead of Image as it represent a collection
        foreach (var img in entity.Images)
        {
            var imgModel = new ViewImageViewModel()
            {
                // you may change this to get the correct Url
                ImageUrl = string.Concat(HttpContext.Request.Url.Scheme, 
                      "://", HttpContext.Request.Url.Host, 
                      HostingEnvironment.ApplicationVirtualPath,
                      img.ImageFilePath),
                Likes = img.NumOfLikes,
                Caption = img.Caption
            };
            model.Images.Add(imgModel);
        }
        return View(model);
    }
    ...
