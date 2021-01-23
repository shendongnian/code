    File body = new File();
            body.Title = "document title";
            body.Description = "document description";
            body.MimeType = "application/vnd.google-apps.folder";
            // service is an authorized Drive API service instance
            File file = service.Files.Insert(body).Execute();
            //File body = new File();
            //body.Title = "My document";
            //body.Description = "A test document";
            //body.MimeType = "text/plain";
            //byte[] byteArray = System.IO.File.ReadAllBytes("document.txt");
            //System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            //FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            //request.Upload();
            //File file = request.ResponseBody;
