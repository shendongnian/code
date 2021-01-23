     if (Request.Form.Files != null && Request.Form.Files.Count > 0)
            {
                var file = Request.Form.Files[0];
                var contentType = file.ContentType;
                using (var fileStream = file.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileStream.CopyToAsync(memoryStream);
                        FileStream newFS = new FileStream(Settings.UserImagesDir + "\\name.png", FileMode.Create);
                        memoryStream.WriteTo(newFS);
                        newFS.Close();                     
                    }
                }
            }
