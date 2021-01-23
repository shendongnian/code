    public void UploadFile1(string fileName, Stream input) {
        // check your security headers here
        string networkPath = WebConfigurationManager.AppSettings["NetWorkPath"];
        using (var fs = File.Create(networkPath + "/" + fileName)) {
            input.CopyTo(fs);
        }
    }
