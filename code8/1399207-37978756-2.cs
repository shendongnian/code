		[HttpPost]
		public IActionResult UploadFile(string filename, Guid id, IFormFile file)
		{
			IPFile ipfile = new IPFile()
			{
				ContentType = file.ContentType,
				DateUploaded = DateTime.Now,
				Filename = filename,
				SharedIPId = (id == Guid.Empty ? (Guid?)null : id), 
				Id = Guid.NewGuid(),
				UploadedBy = User.Alias(),
			};
			ipfile = FileManager.AddFileFromStream(User.Alias(), ipfile, file.OpenReadStream());
			return Ok(ipfile);
		}
