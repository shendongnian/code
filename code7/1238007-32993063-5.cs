        [HttpGet]
        public ActionResult EditUser()
        {
            //
            // LOAD INFO ABOUT THE USER (Using a service layer, but you're probably just using Entity Framework)
            //
        
            // Get the user ID?
            var userId = this.User.Identity.GetUserId();
            
            // Get the user domain models from the database?
            var userDomainModel = this.UserService.GetUserInfo(userId);
        
            // Get the user's image domain models from the database?
            var userImagesDomainModelList = this.UserImageService.GetImagesForUser(userId);
        
            //
            // THE VIEW MODEL MAPPING STARTS HERE...
            //
        
            // Create an instance of your view model and assign basic info
            var responseModel = ProfileViewModel()
            {
                public string UserName = userDomainModel.UserName;
                public string Password = userDomainModel.Password;
                public string FullName = userDomainModel.FullName;
            }
        
            // Initialise list for images
            responseModel.UserImages = new List<ImageViewModel>();
        
            // Loop though each image domain model and assign them to the main view model
            foreach (var imageDomainModel in userImagesDomainModelList)
            {
                 // Initialise image view model
                 var imageViewModel = new ImageViewModel()
                 {
                     ImageID = imageDomainModel.ImageID,
                     ImageCaption = imageDomainModel.ImageCaption,
                     NumOfLikes = imageDomainModel.NumOfLikes,
                     ImageFilePath = imageDomainModel.ImageFilePath
                 };
        
                 // Add the image view model to the main view model
                 responseModel.UserImages.Add(imageViewModel);
            }
        
            // Pass the view model back to the view
            return View(responseModel);
        }
