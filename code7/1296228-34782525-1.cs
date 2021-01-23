    FacebookClient fb = new FacebookClient(token.Trim());
    //Perform upload
    var imageStream = File.OpenRead(photo.Location);
    fb.PostCompleted += (o, e) =>
    {
        imageStream.Dispose();
        if (e.Cancelled || e.Error != null)
        {
            error = e.Error == null ? "canceled" : e.Error.Message;
        }
    };
    dynamic res = fb.PostTaskAsync("/" + fbAlbumID + "/photos", new
    {
        message = String.Empty,
        file = new FacebookMediaStream
        {
            ContentType = "image/jpg",
            FileName = Path.GetFileName(photo.Location)
        }.SetValue(imageStream)
    });
    res.Wait();
    var dictionary = (IDictionary<string, object>)res.Result;
