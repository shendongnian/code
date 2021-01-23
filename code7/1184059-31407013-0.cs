       void UploadStringCallback2(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                object objException = e.Error.GetBaseException();
    
                Type _type = typeof(WebException);
                if (_type != null)
                {
                    WebException objErr = (WebException)e.Error.GetBaseException();
                    WebResponse rsp = objErr.Response;
                    using (Stream respStream = rsp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        string text = reader.ReadToEnd();
                    }
                    throw objErr;
                }
                else
                {
                    Exception objErr = (Exception)e.Error.GetBaseException();
                    throw objErr;
                }
            }
    
         }
