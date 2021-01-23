            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }
          
            HttpPostedFile uploadedFile = HttpContext.Current.Request.Files[0];
             var csv = new CsvReader(uploadedFile.InputStream);
