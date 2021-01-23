    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(FilePath);
    using (HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse()) {
    	using (Stream stream = myResp.GetResponseStream()) {
    	HttpResponse resp = HttpContext.Current.Response;
    	resp.Clear();
    	resp.ContentType = "Application/msword";
    	resp.AddHeader("Content-Disposition", "attachment; filename=xyz.doc");
    	int count = 0;
                    do
                    {
                        byte[] buf = new byte[10240];
                        count = stream.Read(buf, 0, 10240);
                        resp.OutputStream.Write(buf, 0, count);
                        resp.Flush();
                    } while (stream.CanRead && count > 0);
    	}
    }
