     public static void upload(MediaFile mediaFile)
     {
                try
                {
                    StreamContent scontent = new StreamContent(mediaFile.GetStream());
                    scontent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        FileName = "newimage",
                        Name = "image"
                    };
                    scontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
    
                    var client = new HttpClient();
                    var multi = new MultipartFormDataContent();
                    multi.Add(scontent);
                    client.BaseAddress = new Uri(Constants.API_ROOT_URL);
                    var result = client.PostAsync("api/photo", multi).Result;
                    Debug.WriteLine(result.ReasonPhrase);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
      }
