    string user = login.Text;
    string user = login.Text;
    string pass = password.Password;
    ASCIIEncoding encoding = new ASCIIEncoding();
    string postData = "login=" + user + "&mdp=" + pass;
    byte[] data = encoding.GetBytes(postData);
    WebRequest request = WebRequest.Create("myURL/login.php");
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.Headers["ContentLength"] = data.Length.ToString();
    using (Stream stream = await request.GetRequestStreamAsync()) {
       stream.Write(data, 0, data.Length);
    }
    using (WebResponse response = await request.GetResponseAsync()) {
       using (Stream stream = response.GetResponseStream()) {
          using (StreamReader sr = new StreamReader(stream)) {
             //
         }
       }
    }
