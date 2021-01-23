    private Bitmap loadedBitmap;
    ...
    private void requestFrame()
    {    
     string cameraUrl = @"http://192.168.0.1XX:80/Streaming/channels/1/picture?snapShotImageType=JPEG";
     var request = System.Net.HttpWebRequest.Create(cameraUrl);   
     request.Credentials = new NetworkCredential(cameraLogin, cameraPassword);
     request.Proxy = null;
     request.BeginGetResponse(new AsyncCallback(finishRequestFrame), request);
    }
		
    void finishRequestFrame(IAsyncResult result)
    {
     HttpWebResponse response = (result.AsyncState as HttpWebRequest).EndGetResponse(result) as HttpWebResponse;
     Stream responseStream = response.GetResponseStream();
    
     using (Bitmap frame = new Bitmap(responseStream)) {
      if (frame != null) {
       loadedBitmap = (Bitmap) frame.Clone();                        
      }
     }
    }
    ...
    requestFrame(); // call the function
