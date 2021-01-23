    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["StoryBoardSchedulerJobUrl"]);
    webRequest.Method = "POST";
    var data = string.Format("lastUpdateTime={0}", Uri.EscapeDataString(DateTime.Now.ToString()));
    byte[] byteArray = Encoding.UTF8.GetBytes(data);
    webRequest.ContentType = "application/x-www-form-urlencoded"
    webRequest.ContentLength = byteArray.Length;
    StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
    requestWriter.Write(byteArray);
    requestWriter.Close();
    var response = (HttpWebResponse)webRequest.GetResponse(); 
