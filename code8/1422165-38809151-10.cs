    System.Drawing.Image img = null;
     //accept Charset "ISO-8859-1"
     request.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1");
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
     Stream stream = response.GetResponseStream();
     img = System.Drawing.Image.FromStream(stream);
      .......
    }
     return img;
