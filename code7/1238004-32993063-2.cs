        [HttpPost]
        public ActionResult UpdateImage(UpdateImageViewModel requestResponseModel)
        {   
            // Get the user ID?
            var userId = this.User.Identity.GetUserId();
    
            // Map incoming view model values to domain model
            var imageDomainModel = new Image()
            {
                ImageID = requestResponseModel.ImageId,
                ImageCaption = requestResponseModel.ImageCaption,
                NumOfLikes = requestResponseModel.NumOfLikes,
                ImageFilePath = requestResponseModel.ImageFilePath,
            }
    
            try
            {
                // Send the domain model up to your service layer ready to be saved
                this.UserImageService.UpdateImage(userId, imageDomainModel);
                
                ViewBag.SuccessMessage = "Your image was updated";
            }
            catch (Exception)
            {
                // Critical error saving user image
            }
    
            return View(requestResponseModel);
        }
