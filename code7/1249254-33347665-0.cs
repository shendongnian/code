        private Object myLock= new Object();
    
        foreach (string fileName in request.Files)
                {
                    var companyName = request.Form.Get(0);
                    var productId = request.Form.Get(1);
                    if (string.IsNullOrWhiteSpace(companyName))
                    {
                        throw new Exception("No company found!");
                    }
                    if (string.IsNullOrWhiteSpace(productId))
                    {
                        throw new Exception("No product picked!");
                    }
                    HttpPostedFileBase file = request.Files[fileName];
                    if (file != null && file.ContentLength > 0)
                    {
    
                        lock (myLock)
                        {
                            //This is the method that calls the API
                            SaveUploadResource(file, companyName, productId);
                        }
                    }
                }
