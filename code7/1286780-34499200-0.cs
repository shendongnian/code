    WebClient wb = new WebClient();
    wb.Headers.Add("Authorization","Bearer" +AccessToken);
    var file =  wb.DownloadData(new Uri("http://testclient.xitech.com.au/Videos/Images/Closing_2051.jpg"));
    var asByteArrayContent = wb.UploadData(new Uri(picture_resource_request ), "PUT", file);
    var asStringContent = Encoding.UTF8.GetString(asByteArrayContent);
