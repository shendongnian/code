    Bitmap    myImage = new Bitmap("myImage.jpg");
    byte[] myFileData = (byte[])(new ImageConverter()).ConvertTo(myImage, typeof(byte[]));
    string myBoundary = "---------------------------7df3c13714f0ffc";
    var       newLine = Environment.NewLine;
    string  myContent =
      "--" + myBoundary + newLine + 
      "Content-Disposition: form-data; name=\"image\"; filename=\"myImage.jpg\"" + newLine +
      "Content-Type: image/jpeg" + newLine +
      newLine +
      Encoding.Default.GetString(myFileData) + newLine +
      "--" + myBoundary + "--";
    using (var client = new WebClient()) {
        try {
            client.Headers["Authorization"] = "Basic xxxxxx";
            client.Headers["Content-Type"]  = "multipart/form-data; boundary=" + myBoundary;
            client.UploadString(new Uri(myURL), "POST", myContent);
            totalAPICalls++;
        }
        catch { }
    }
