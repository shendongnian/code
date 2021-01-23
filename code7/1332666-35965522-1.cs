            var myModel = new MyModel();
            var root = HttpContext.Current.Server.MapPath("~/App_Data/");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);
            //Maps fields from form data into my custom model
            foreach (var key in provider.FormData.AllKeys)
            {
                var value = provider.FormData.GetValues(key).FirstOrDefault();
                if (value != null && value != "undefined")
                {
                    var prop = myModel.GetType().GetProperty(key);
                    if (prop != null)
                    {
                        prop.SetValue(myModel, value, null);
                    }
                }
            }
              //Resaves all files in my custom location under App_Data and puts their paths into list
                var fileNames = new Collection<string>();
               foreach (var file in provider.FileData)
                {
                    var fileExt = file.Headers.ContentDisposition.FileName.Split('.').Last().Replace("\"", string.Empty);
                    var combinedFileName = string.Format("{0}.{2}", file.Headers.ContentDisposition.Name.Replace("\"", string.Empty), fileExt);
                    var combinedPath = Path.Combine(root + "CustomDirectory/", combinedFileName);
                    File.Move(file.LocalFileName, combinedPath);
                    fileNames.Add(combinedPath);
                }
