		try
		{
			foreach (string file in Request.Files)
			{
				var fileContent = Request.Files[file];
				if (fileContent != null && fileContent.ContentLength > 0)
				{ 
					// get a stream
					var stream = fileContent.InputStream;
				   // and write the file to disk
				   var fileName = Path.GetFileName(file); 
				   var path = Path.Combine(Server.MapPath("~/Junk"), fileName); 
				   using (var fileStream = File.Create(path))
				   {
					   stream.CopyTo(fileStream);
				   }
			   }
			}
		}
		catch (Exception)
		{
			Response.StatusCode = (int)HttpStatusCode.BadRequest;
			return Json("Upload failed");
		}
		
		return Json("Upload succeeded");
	}
