    bool imageexist = false;
            //check if image exist on given url or not
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(item.image.ToString()));
                using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
                {
                    int imagelength = Convert.ToInt32(response.ContentLength);
                    if (imagelength > 0)
                        imageexist = true;
                    else
                        imageexist = false;
                }
            }
            catch (Exception)
            {
                imageexist = false;
            }
    
