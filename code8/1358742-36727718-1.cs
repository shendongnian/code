    byte[] data = Encoding.ASCII.GetBytes(
        $"username={user}&password={password}");
    
    WebRequest request = WebRequest.Create("http://localhost/s/test3.php");
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = data.Length;
    using (Stream stream = request.GetRequestStream())
    {
        stream.Write(data, 0, data.Length);
    }
    string responseContent = null;
    using (WebResponse response = request.GetResponse())
    {
        using (Stream stream = response.GetResponseStream())
        {
            using (StreamReader sr99 = new StreamReader(stream))
            {
                responseContent = sr99.ReadToEnd();
            }
        }
    }
    MessageBox.Show(responseContent);
