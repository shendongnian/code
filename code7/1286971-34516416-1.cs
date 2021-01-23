    WebClient wb = new WebClient();
                    wb.Headers.Add("Authorization","Bearer" +vc.AccessToken);
                    var file = wb.DownloadData(new Uri(myimageurl));
                    var asByteArrayContent = wb.UploadData(new Uri(thumbnail_uri), "PUT", file);
                    var asStringContent = Encoding.UTF8.GetString(asByteArrayContent);
