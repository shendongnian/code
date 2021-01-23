    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, f.FileName));
    httpWebRequest.Timeout = 14400000;
    httpWebRequest.KeepAlive = true;
    using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
    {
        //Do stuff
    }
