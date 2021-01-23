      [HttpPost]
            public IHttpActionResult AddCandidateProfilePicture()
            {
                var request = HttpContext.Current.Request;
                const int maxContentLength = 512 * 512 * 1;
        
                if (request.ContentLength > maxContentLength || 
                    request.Files.Count == 0)
                    return BadRequest();
        
                var pictureFile = request.Files[0];
        
                var result = 
    AddCandidateProfilePictureCommand.Execute(pictureFile);
        
                return Ok(result);
            }
