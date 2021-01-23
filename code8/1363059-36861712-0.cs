        [HttpPost]  
        public async Task<HttpResponseMessage> UploadDoc()
        {
            try
            {
              
                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);
                if (System.Web.HttpContext.Current.Request.Files.Count > 0)
                {
                    foreach (string file in System.Web.HttpContext.Current.Request.Files)
                    {
                        byte[] postedFile = null;
                        using (var binaryReader = new BinaryReader(System.Web.HttpContext.Current.Request.Files[file].InputStream))
                        {
                            postedFile = binaryReader.ReadBytes(System.Web.HttpContext.Current.Request.Files[file].ContentLength);
                          
                        }
                        string fileName = System.Web.HttpContext.Current.Request.Files.AllKeys[0];
                    }
                }
                await Request.Content.ReadAsMultipartAsync(provider);
